using System.Net;
using System.Net.Http;
using BranchNet.Extensions;
using BranchNet.Models;

namespace BranchNet.Response
{
    public class UrlResponse : BranchBaseResponse
    {
        public UrlResponse(string body, HttpStatusCode statusCode, HttpResponseMessage httpResponse)
            : base(body, statusCode, httpResponse)
        {
        }

        public UrlResponse(string body, HttpStatusCode statusCode)
            : base(body, statusCode)
        {
        }

        public UrlResult Result
        {
            get { return ResultAs<UrlResult>(); }
        }
    }

    public class UrlResult
    {
        public string Url { get; set; }
    }
}
