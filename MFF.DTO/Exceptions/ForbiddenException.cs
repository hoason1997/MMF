using System;

namespace MFF.DTO.Exceptions
{
    /// <summary>
    /// ForbiddenException class
    /// </summary>
    [Serializable]
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ForbiddenException() : base(string.Empty)
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        public ForbiddenException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        public ForbiddenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
