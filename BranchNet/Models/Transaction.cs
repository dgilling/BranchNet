using System;
using System.Net;
using System.Net.Http;
using BranchNet.Extensions;
using BranchNet.Constants;

namespace BranchNet.Models
{

    public class Transaction
    {
        public DateTime Date { get; set; }

        public string Id { get; set; }

        public string Bucket { get; set; }

        public CreditType Type { get; set; }

        public int Amount { get; set; }
    }
}

