using MFF.DTO.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Net;

namespace MFF.DTO.Helpers
{
    /// <summary>
    /// ResponseHelper class
    /// </summary>
    public static class ResponseHelper
    {
        /// <summary>
        /// Response format
        /// </summary>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static ObjectResult ToObjectResult(bool success = true
            , object data = null
            , string message = null
            , string errorCode = null
            , HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            if (true)
            {
                var apiResponse = new DataResponse()
                {
                    Status = success ? 1 : 0,
                    Message = message,
                    Code = errorCode,
                    Data = data
                };
                return new ObjectResult(apiResponse) { StatusCode = (int)httpStatusCode };
            }
        }

        /// <summary>
        /// Success wihthout data
        /// </summary>
        /// <returns></returns>
        public static ObjectResult Success()
        {
            return ToObjectResult(true
                , null
                , MessageConstant.SUCCESS_RESPONSE
                , null
                , HttpStatusCode.OK);
        }

        /// <summary>
        /// Success with data helper
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ObjectResult Success(object data = null)
        {
            return ToObjectResult(true
                , data
                , null
                , null
                , HttpStatusCode.OK);
        }

        /// <summary>
        /// Success with data and message helper
        /// </summary>
        /// <param name="successMsg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ObjectResult Success(string successMsg = null, object data = null)
        {
            return ToObjectResult(true
                , data
                , successMsg
                , null
                , HttpStatusCode.OK);
        }

        /// <summary>
        /// Created response helper
        /// </summary>
        /// <param name="successMsg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ObjectResult Created(string successMsg = null, object data = null)
        {
            return ToObjectResult(true
                , data
                , successMsg
                , null
                , HttpStatusCode.Created);
        }

        /// <summary>
        /// Model State badRequest helper
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static ObjectResult BadRequest(ModelStateDictionary modelState)
        {
            string errorMsg = null;
            var error = modelState.SelectMany(x => x.Value.Errors).First();
            if (!string.IsNullOrEmpty(error.ErrorMessage))
                errorMsg = error.ErrorMessage;
            else if (error.Exception?.Message != null)
                errorMsg = error.Exception.Message;

            return ToObjectResult(false
                , null
                , errorMsg
                , MessageConstant.BAD_ARGRUMENT
                , HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// BadRequest with message
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static ObjectResult BadRequest(string errorMsg
            , string errorCode = null)
        {
            return ToObjectResult(false, null, errorMsg, errorCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Not found helper
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static ObjectResult NotFound(string errorMsg
            , string errorCode = null)
        {
            return ToObjectResult(false, null, errorMsg, errorCode, HttpStatusCode.NotFound);
        }
    }

    internal class DataResponse : BaseResponse
    {
        public string Code { get; set; }
        public object Data { get; set; }
    }

    internal class ErrorResponse : BaseResponse
    {
        public string Code { get; set; }
    }

    internal class BaseResponse
    {
        public int Status { get; set; }

        public string Message { get; set; }
    }
}
