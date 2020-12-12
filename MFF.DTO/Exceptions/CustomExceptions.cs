using System;
using System.Net;

namespace MFF.DTO.Exceptions
{
    /// <summary>
    /// CustomException class
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// constructor no parameter
        /// </summary>
        public CustomException() : base() { }

        /// <summary>
        /// constructor with message
        /// </summary>
        /// <param name="message"></param>
        public CustomException(string message) : base(message) { }

        /// <summary>
        /// constructor with message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public CustomException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// http status code
        /// </summary>
        public HttpStatusCode? HttpStatusCode { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        public string ErrorCode { get; set; }
    }
}
