using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BranchNet.Extensions;
using BranchNet.Models;

namespace BranchNet.Response
{
    public class CreditCountResponse : BranchBaseResponse
    {
        public CreditCountResponse(string body, HttpStatusCode statusCode, HttpResponseMessage httpResponse)
            : base(body, statusCode, httpResponse)
        {
        }

        public CreditCountResponse(string body, HttpStatusCode statusCode)
            : base(body, statusCode)
        {
        }

        public Dictionary<string, int> Result
        {
            get { return ResultAs<Dictionary<string, int>>(); }
        }
    }
}
