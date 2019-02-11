using System;
using BranchNet.HttpService;
using BranchNet.Serializer;
using System.Runtime.Serialization;

namespace BranchNet.Constants
{
    public enum UrlType
    {
        // Default Unlimited Use Branch Referral links
        UNLIMITED_USE = 0,

        // One Time Use URL
        ONE_TIME_USE = 1,

        // Marketing URL
        MARKETING = 2,
    }
}
