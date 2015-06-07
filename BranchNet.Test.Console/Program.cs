using System;
using BranchNet.Config;
using BranchNet.Models;
using BranchNet.Response;

namespace BranchNet.Test.Console
{
    public class Program
    {

        private static BranchClient _client;

        private static void Main()
        {
            IBranchConfig config = new BranchConfig
            {
        //        BranchKey    = BRANCH_KEY,
        //        BranchSecret = BRANCH_SECRET
            };

            _client = new BranchClient(config); 


        }

    }
}