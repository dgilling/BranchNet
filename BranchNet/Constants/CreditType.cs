using System;
using BranchNet.HttpService;
using BranchNet.Serializer;
using System.Runtime.Serialization;

namespace BranchNet.Constants
{
    public enum CreditType
    {
        // A reward that was added automatically by the user completing an action or referral.
        USER_ACTION_REWARD = 0,

        // A reward that was added manually.
        MANUAL_REWARD = 1,

        // A redemption of credits that occurred through our API or SDKs.
        REDEMPTION = 2,

        // This is a very unique case where we will subtract credits automatically when we detect fraud.
        FRAUD_RECONCILE_A = 3,

        FRAUD_RECONCILE_B = 5,
        
        // This is the type when you reconcile credits manually
        MANUAL_RECONCILE = 4,
    }
}
