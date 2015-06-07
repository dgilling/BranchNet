using System;
using BranchNet.HttpService;
using BranchNet.Serializer;
using BranchNet.Constants;

namespace BranchNet.Config
{
    public class BranchConfig : IBranchConfig
    {
        public BranchConfig()
        {
        }

        public string BranchKey { get; set; }

        public string BranchSecret { get; set; }

        public TimeSpan? RequestTimeout { get; set; }
    }
}
