using System;
using BranchNet.Config;
using BranchNet.Models;
using BranchNet.Response;
using BranchNet.Constants;

namespace BranchNet.Test.Console
{
    public class Program
    {

        private static BranchClient _client;

        private static void Main()
        {
            IBranchConfig config = new BranchConfig
            {
                BranchKey    = "key_live_aonBKeiWFsNv4tRCI6lYshegcfn6E42l",
                BranchSecret = "secret_live_KfOpMbeBhy8zABnsYRxo3GrDbmxqBEA5"
            };

            _client = new BranchClient(config);

            createUrl(16);
            getHistory(16);
        }

        private static void createUrl(long identity)
        {
            var payload = new UrlParameters<UrlDataParameters>()
            {
                Data = new UrlDataParameters()
                {
                    OgTitle = "OG Title",
                    OgDescription = "OG Test Description",
                    OgImageUrl = "https://usetrovedevelopment.blob.core.windows.net/photos/stock/ad_whiteboard_market_browse.png",
                    OgVideo = "https://www.youtube.com/v/_NFjLgAJ5E0",
                    DesktopUrl = "www.usetrove.com",
                    AndroidUrl = "https://play.google.com/store/apps/details?id=com.trove.trove&hl=en",
                    IosUrl = "https://itunes.apple.com/app/id959403436",
                    IPadUrl = "https://itunes.apple.com/app/id959403436",

                },
                Type = UrlType.MARKETING,
                Duration = 100,
                Identity = identity.ToString(),
                Tags = null,
                Campaign = "test",
                Feature = BranchConstants.FEATURE_TAG_REFERRAL
            };

            try
            {

                var syncResponse = _client.CreateUrl<UrlParameters<UrlDataParameters>, UrlDataParameters>(payload);
                System.Console.WriteLine(syncResponse.Result);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return;
        }

        private static void getHistory(long identity)
        {
            try
            {

                var syncResponse = _client.GetCreditHistory(identity.ToString());
                System.Console.WriteLine(syncResponse.Result);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return;
        }

    }
}