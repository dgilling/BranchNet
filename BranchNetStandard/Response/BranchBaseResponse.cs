using System.Net;
using System.Net.Http;
using BranchNet.Extensions;
using BranchNet.Models;

namespace BranchNet.Response
{
    public class BranchBaseResponse
    {
        private readonly HttpStatusCode _statusCode;

        protected readonly HttpResponseMessage HttpResponse;
        private readonly string _body;

        public BranchBaseResponse(string body, HttpStatusCode statusCode, HttpResponseMessage httpResponse)
        {
            _statusCode = statusCode;
            _body = body;
            HttpResponse = httpResponse;
        }

        public BranchBaseResponse(string body, HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
            _body = body;
        }

        public string Body
        {
            get { return _body; }
        }

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
        }

        public virtual T ResultAs<T>()
        {
            return Body.ReadAs<T>();
        }
    }
}
