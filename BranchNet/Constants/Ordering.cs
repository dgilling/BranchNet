using System;
using BranchNet.HttpService;
using BranchNet.Serializer;
using System.Runtime.Serialization;

namespace BranchNet.Constants
{
    public enum Ordering
    {
        [EnumMember(Value = "asc")]
        asc,

        [EnumMember(Value = "desc")]
        desc
    }
}
