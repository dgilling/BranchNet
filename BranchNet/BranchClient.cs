using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using BranchNet.Constants;
using BranchNet.Config;
using BranchNet.Exceptions;
using BranchNet.HttpService;
using BranchNet.Response;
using BranchNet.Models;

namespace BranchNet
{
    public class BranchClient : IBranchClient, IDisposable
    {
        private readonly IHttpService _requestManager;
        private readonly IBranchConfig   _config;

        private readonly Action<HttpStatusCode, string> _defaultErrorHandler = (statusCode, body) =>
        {
            if (statusCode == HttpStatusCode.PaymentRequired)
            {
                throw new BranchException(statusCode, "Not enough credits available");
            }
            if (statusCode < HttpStatusCode.OK || statusCode >= HttpStatusCode.BadRequest)
            {
                throw new BranchException(statusCode, body);
            }
        };


        public BranchClient(IBranchConfig config)
            : this(new HttpService.HttpService(config))
        {
            _config = config;
        }

        internal BranchClient(IHttpService requestManager)
        {
            _requestManager = requestManager;
        }

        public void Dispose()
        {
            using (_requestManager) { }
        }

        public UrlResponse CreateUrl<U, D>(U parameters) where U : UrlParameters<D>
                                                         where D : UrlDataParameters
        {
            try
            {
                string path = "/v1/url";
                HttpResponseMessage response = _requestManager.RequestAsync(HttpMethod.Post, path, parameters).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                HandleIfErrorResponse(response.StatusCode, content);
                return new UrlResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public CreditCountResponse GetCreditCount(string identity)
        {
            try
            {
                string path = String.Format("/v1/credits?branch_key={0}&identity={1}", _config.BranchKey, identity);
                HttpResponseMessage response = _requestManager.RequestAsync(HttpMethod.Get, path).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                HandleIfErrorResponse(response.StatusCode, content);
                return new CreditCountResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public SuccessResponse AddCredits(CreditParameters parameters)
        {
            try
            {
                string path = "/v1/credits";
                HttpResponseMessage response = _requestManager.RequestAsync(HttpMethod.Post, path, parameters).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                HandleIfErrorResponse(response.StatusCode, content);
                return new SuccessResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public void RedeemCredits(CreditParameters parameters)
        {
            try
            {
                string path = "/v1/redeem";
                HttpResponseMessage response = _requestManager.RequestAsync(HttpMethod.Post, path, parameters).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                HandleIfErrorResponse(response.StatusCode, content);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public ReconcileTransactionResponse ReconcileCredits(CreditParameters parameters)
        {
            try
            {
                string path = "/v1/reconcile";
                HttpResponseMessage response = _requestManager.RequestAsync(HttpMethod.Post, path, parameters).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                HandleIfErrorResponse(response.StatusCode, content);
                return new ReconcileTransactionResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public CreditQueryResponse GetCreditHistory(string identity,
                                                   string bucket = null,
                                                   int? beginAfterId = null,
                                                   int? length = null,
                                                   Ordering direction = Ordering.desc)
        {
            try
            {
                StringBuilder builder = new StringBuilder("/v1/credithistory?branch_key=");
                builder.Append(_config.BranchKey);
                builder.Append("&identity=");
                builder.Append(identity);

                if (bucket != null)
                {
                    builder.Append("&bucket=");
                    builder.Append(bucket.ToString());
                }
                
                if (beginAfterId.HasValue)
                {
                    builder.Append("&begin_after_id=");
                    builder.Append(beginAfterId.ToString());
                }

                if (length.HasValue)
                {
                    builder.Append("&length=");
                    builder.Append(length.ToString());
                }

                builder.Append("&direction=");
                builder.Append(direction.ToString());


                HttpResponseMessage response = _requestManager.RequestAsync(HttpMethod.Get, builder.ToString()).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                HandleIfErrorResponse(response.StatusCode, content);
                return new CreditQueryResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        // Async Versions
        public async Task<UrlResponse> CreateUrlAsync<U, D>(U parameters) where U : UrlParameters<D>
                                                                          where D : UrlDataParameters
        {
            try
            {
                string path = "/v1/url";
                HttpResponseMessage response = await _requestManager.RequestAsync(HttpMethod.Post, path, parameters).ConfigureAwait(false);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HandleIfErrorResponse(response.StatusCode, content);
                return new UrlResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public async Task<CreditCountResponse> GetCreditCountAsync(string identity)
        {
            try
            {
                string path = String.Format("/v1/credits?branch_key={0}&identity={1}", _config.BranchKey, identity);
                HttpResponseMessage response = await _requestManager.RequestAsync(HttpMethod.Get, path).ConfigureAwait(false);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HandleIfErrorResponse(response.StatusCode, content);
                return new CreditCountResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public async Task<SuccessResponse> AddCreditsAsync(CreditParameters parameters)
        {
            try
            {
                string path = "/v1/credits";
                HttpResponseMessage response = await _requestManager.RequestAsync(HttpMethod.Post, path, parameters).ConfigureAwait(false);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HandleIfErrorResponse(response.StatusCode, content);
                return new SuccessResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public async Task RedeemCreditsAsync(CreditParameters parameters)
        {
            try
            {
                string path = "/v1/redeem";
                HttpResponseMessage response = await _requestManager.RequestAsync(HttpMethod.Post, path, parameters).ConfigureAwait(false);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HandleIfErrorResponse(response.StatusCode, content);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public async Task<ReconcileTransactionResponse> ReconcileCreditsAsync(CreditParameters parameters)
        {
            try
            {
                string path = "/v1/reconcile";
                HttpResponseMessage response = await _requestManager.RequestAsync(HttpMethod.Post, path, parameters).ConfigureAwait(false);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HandleIfErrorResponse(response.StatusCode, content);
                return new ReconcileTransactionResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        public async Task<CreditQueryResponse> GetCreditHistoryAsync(string identity,
                                                                     string bucket = null,
                                                                     int? beginAfterId = null,
                                                                     int? length = null,
                                                                     Ordering direction = Ordering.desc)
        {
            try
            {
                StringBuilder builder = new StringBuilder("/v1/credithistory?branch_key=");
                builder.Append(_config.BranchKey);
                builder.Append("&identity=");
                builder.Append(identity);

                if (bucket != null)
                {
                    builder.Append("&bucket=");
                    builder.Append(bucket.ToString());
                }

                if (beginAfterId.HasValue)
                {
                    builder.Append("&begin_after_id=");
                    builder.Append(beginAfterId.ToString());
                }

                if (length.HasValue)
                {
                    builder.Append("&length=");
                    builder.Append(length.ToString());
                }

                builder.Append("&direction=");
                builder.Append(direction.ToString());


                HttpResponseMessage response = await _requestManager.RequestAsync(HttpMethod.Get, builder.ToString()).ConfigureAwait(false);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HandleIfErrorResponse(response.StatusCode, content);
                return new CreditQueryResponse(content, response.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                throw new BranchException(ex);
            }
        }

        private void HandleIfErrorResponse(HttpStatusCode statusCode, string content, Action<HttpStatusCode, string> errorHandler = null)
        {
            if (errorHandler != null)
            {
                errorHandler(statusCode, content);
            }
            else
            {
                _defaultErrorHandler(statusCode, content);
            }
        }
    }
}