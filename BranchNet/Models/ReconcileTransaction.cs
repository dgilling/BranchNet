using System;
using System.Net;
using System.Net.Http;
using BranchNet.Extensions;

namespace BranchNet.Models
{
    public class ReconcileTransaction : Transaction
    {
        public string AppId { get; set; }

        public string IdentityId { get; set; }
    }
}
