using System;
using System.Net;

namespace BranchNet.Exceptions
{
    public class BranchException : Exception
    {
        public BranchException(string message)
            : base(message)
        {
        }

        public BranchException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BranchException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        public BranchException(HttpStatusCode statusCode, string responseBody)
            : base(string.Format("Request responded with status code={0}, response={1}", statusCode, responseBody))
        {

        }
    }
}