using System;
using System.Threading.Tasks;
using BranchNet.Response;
using BranchNet.Models;
using BranchNet.Constants;

namespace BranchNet.HttpService
{
    public interface IBranchClient
    {
        // Synchronous Methods
        UrlResponse CreateUrl<U, D>(U parameters) where U : UrlParameters<D>
                                                  where D : UrlDataParameters;

        CreditCountResponse GetCreditCount(string identity);

        SuccessResponse AddCredits(CreditParameters parameters);

        void RedeemCredits(CreditParameters parameters);

        ReconcileTransactionResponse ReconcileCredits(CreditParameters parameters);

        CreditQueryResponse GetCreditHistory(string identity,
                                             string bucket = null,
                                             int? beginAfterId = null,
                                             int? length = null,
                                             Ordering direction = Ordering.desc);


        // Async Methods
        Task<UrlResponse> CreateUrlAsync<U, D>(U parameters) where U : UrlParameters<D>
                                                             where D : UrlDataParameters;

        Task<CreditCountResponse> GetCreditCountAsync(string identity);

        Task<SuccessResponse> AddCreditsAsync(CreditParameters parameters);

        Task RedeemCreditsAsync(CreditParameters parameters);

        Task<ReconcileTransactionResponse> ReconcileCreditsAsync(CreditParameters parameters);

        Task<CreditQueryResponse> GetCreditHistoryAsync(string identity,
                                                        string bucket = null,
                                                        int? beginAfterId = null,
                                                        int? length = null,
                                                        Ordering direction = Ordering.desc);

    }
}