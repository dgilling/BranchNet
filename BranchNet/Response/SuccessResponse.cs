using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BranchNet.Extensions;
using BranchNet.Models;

namespace BranchNet.Response
{
    public class SuccessResponse : BranchBaseResponse
    {
        public SuccessResponse(string body, HttpStatusCode statusCode, HttpResponseMessage httpResponse)
            : base(body, statusCode, httpResponse)
        {
        }

        public SuccessResponse(string body, HttpStatusCode statusCode)
            : base(body, statusCode)
        {
        }

        public SuccessResult Result
        {
            get { return ResultAs<SuccessResult>(); }
        }
    }

    public class SuccessResult
    {
        public bool Success { get; set; }
    }
}
