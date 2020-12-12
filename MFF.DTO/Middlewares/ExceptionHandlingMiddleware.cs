using MFF.DTO.Constants;
using MFF.DTO.Exceptions;
using MFF.DTO.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MFF.DTO.Middlewares
{
    /// <summary>
    /// Exception handle middleware class
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invoke action
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
                return;

            var httpStatusCode = HttpStatusCode.InternalServerError;
            string message;
            string errorCode;
            if (exception is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                errorCode = MessageConstant.UNAUTHORIZED;
                message = exception.Message;
            }
            else if (exception is MethodAccessException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                var messageObj = CommonHelper.GetPropValue<MessageConstant>(exception.Message);
                errorCode = messageObj == null ? MessageConstant.NOT_FOUND : exception.Message;
                message = messageObj == null ? exception.Message : messageObj.ToString();
            }
            else if (exception is ArgumentException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
                var messageObj = CommonHelper.GetPropValue<MessageConstant>(exception.Message);
                errorCode = messageObj == null ? MessageConstant.BAD_ARGRUMENT : exception.Message;
                message = messageObj == null ? exception.Message : messageObj.ToString();
            }
            else if (exception is ForbiddenException)
            {
                httpStatusCode = HttpStatusCode.Forbidden;
                errorCode = MessageConstant.FORBIDDEN;
                message = string.IsNullOrEmpty(exception.Message) ? MessageConstant.FORBIDDEN_ERROR : exception.Message;
            }
            else if (exception is CustomException exc)
            {
                httpStatusCode = exc.HttpStatusCode ?? HttpStatusCode.InternalServerError;
                if (string.IsNullOrEmpty(exc.ErrorCode))
                {
                    var messageObj = CommonHelper.GetPropValue<MessageConstant>(exception.Message);
                    errorCode = messageObj == null ? MessageConstant.UNSPECIFIED : exception.Message;
                    message = messageObj == null ? exception.Message : messageObj.ToString();
                }
                else
                {
                    errorCode = exc.ErrorCode;
                    message = exc.Message;
                }
            }
            else
            {
                var requestAsString = await FormatRequest(context);
                var log = $"\n<br>{requestAsString}" +
                    $"\n<br>Error: {exception.ToString()}";

                //await commonService.SendLogToSystemAdmin($"Error occurred at: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz")}: {log}");

                log = log.Replace("<br>", string.Empty);
                Log.Error(log);

                errorCode = MessageConstant.INTERNAL_SERVER;
                message = MessageConstant.INTERNAL_ERROR;
            }

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;
            var obj = ResponseHelper.ToObjectResult(false, null, message, errorCode, httpStatusCode).Value;
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            await response.WriteAsync(json).ConfigureAwait(false);
        }

        private async Task<string> FormatRequest(HttpContext context)
        {
            var bodyAsText = string.Empty;

            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, false, 1024, true))
            {
                var body = await reader.ReadToEndAsync();
                context.Request.Body.Seek(0, SeekOrigin.Begin);
            }

            using (var bodyReader = new StreamReader(context.Request.Body))
            {
                bodyAsText = await bodyReader.ReadToEndAsync();
            }

            // Hide request password
            if (!string.IsNullOrEmpty(bodyAsText) && bodyAsText.ToLower().Contains("password"))
            {
                var json = JObject.Parse(bodyAsText);
                var jProperties = json.Descendants()
                                    .OfType<JProperty>()
                                    .Where(p => p.Value != null
                                                && !string.IsNullOrEmpty(p.Value.ToString())
                                                && !string.IsNullOrEmpty(p.Name)
                                                && p.Name.ToString().ToLower().Contains("password"))
                                    .ToList();
                if (jProperties != null && jProperties.Any())
                {
                    jProperties.ForEach(x => x.Value = "Sensitive field, can not display");
                    bodyAsText = JsonConvert.SerializeObject(json);
                }
            }

            return $"Scheme: {context.Request.Scheme}" +
                $"\n<br>Host: {context.Request.Host}" +
                $"\n<br>Path: {context.Request.Path}" +
                $"\n<br>Query: {context.Request.QueryString}" +
                $"\n<br>Method: {context.Request.Method}" +
                $"\n<br>Body: {bodyAsText}";
        }
    }
}
