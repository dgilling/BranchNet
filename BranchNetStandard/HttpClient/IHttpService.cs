using System;
using System.Net.Http;
using System.Threading.Tasks;
using BranchNet.Models;

namespace BranchNet.HttpService
{
    internal interface IHttpService : IDisposable
    {
        Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, BaseAuthenticatedPayload payload = null);
    }
}