using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BranchNet.Extensions;
using BranchNet.Models;

namespace BranchNet.Response
{
    public class CreditQueryResponse : BranchBaseResponse
    {
        public CreditQueryResponse(string body, HttpStatusCode statusCode, HttpResponseMessage httpResponse)
            : base(body, statusCode, httpResponse)
        {
        }

        public CreditQueryResponse(string body, HttpStatusCode statusCode)
            : base(body, statusCode)
        {
        }

        public IEnumerable<CreditQuery> Result
        {
            get { return ResultAs<IEnumerable<CreditQuery>>(); }
        }
    }
}