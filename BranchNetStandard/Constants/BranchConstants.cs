using System;
using BranchNet.HttpService;
using BranchNet.Serializer;

namespace BranchNet.Constants
{
    public class BranchConstants
    {
        public const string FEATURE_TAG_SHARE = "share";
        public const string FEATURE_TAG_REFERRAL = "referral";
        public const string FEATURE_TAG_INVITE = "invite";
        public const string FEATURE_TAG_DEAL = "deal";
        public const string FEATURE_TAG_GIFT = "gift";

        public const string REFERRAL_BUCKET_DEFAULT = "default";

        internal const string API_ENDPOINT_BASE_ADDRESS = "https://api2.branch.io/";
    }
}
