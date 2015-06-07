using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BranchNet.Constants;
using BranchNet.Config;
using BranchNet.Exceptions;
using BranchNet.Models;
using BranchNet.Serializer;

namespace BranchNet.HttpService
{
    internal class HttpService : IHttpService
    {
        private readonly IBranchConfig _config;
        private readonly ISerializer   _serializer;

        internal HttpService(IBranchConfig config)
        {
            _config     = config;
            _serializer = new JsonNetSerializer();
        }

        private HttpClient GetClient(HttpClientHandler handler = null)
        {
            var client = handler == null ? new HttpClient() : new HttpClient(handler, true);

            client.BaseAddress = new Uri(BranchConstants.API_ENDPOINT_BASE_ADDRESS);

            if (_config.RequestTimeout.HasValue)
            {
                client.Timeout = _config.RequestTimeout.Value;
            }

            return client;
        }

        public void Dispose()
        {
        }

        public Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, BaseAuthenticatedPayload payload)
        {
            try
            {
                var request = PrepareRequest(method, path, payload);

                return GetClient().SendAsync(request, HttpCompletionOption.ResponseContentRead);
            }
            catch (Exception ex)
            {
                throw new BranchException(
                    string.Format("An error occured while execute request. Path : {0} , Method : {1}", path, method), ex);
            }
        }

        private HttpRequestMessage PrepareRequest(HttpMethod method, string path, BaseAuthenticatedPayload payload)
        {
            var uri = PrepareUri(path);

            var request = new HttpRequestMessage(method, uri);

            if (payload != null)
            {
                payload.BranchKey    = _config.BranchKey;
                payload.BranchSecret = _config.BranchSecret;
                var json = _serializer.Serialize(payload);
                request.Content = new StringContent(json);
            }

            return request;
        }

        private Uri PrepareUri(string path)
        {
            var url = string.Format("{0}{1}", BranchConstants.API_ENDPOINT_BASE_ADDRESS, path);
            return new Uri(url);
        }
    }
}