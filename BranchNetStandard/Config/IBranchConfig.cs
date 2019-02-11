using System;
using BranchNet.HttpService;
using BranchNet.Serializer;

namespace BranchNet.Config
{
    public interface IBranchConfig
    {
        string BranchKey { get; set; }

        string BranchSecret { get; set; }

        TimeSpan? RequestTimeout { get; set; }
    }
}