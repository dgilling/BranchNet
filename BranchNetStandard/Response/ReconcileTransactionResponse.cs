using System;
using System.Net;
using System.Net.Http;
using BranchNet.Extensions;
using BranchNet.Models;

namespace BranchNet.Response
{
    public class ReconcileTransactionResponse : BranchBaseResponse
    {
        public ReconcileTransactionResponse(string body, HttpStatusCode statusCode, HttpResponseMessage httpResponse)
            : base(body, statusCode, httpResponse)
        {
        }

        public ReconcileTransactionResponse(string body, HttpStatusCode statusCode)
            : base(body, statusCode)
        {
        }

        public ReconcileTransaction Result
        {
            get { return ResultAs<ReconcileTransaction>(); }
        }
    }
}
