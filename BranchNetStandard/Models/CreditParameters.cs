using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BranchNet.Extensions;
using Newtonsoft.Json;

namespace BranchNet.Models
{
    public class CreditParameters : BaseAuthenticatedPayload
    {
        public CreditParameters(string identity, int amount, string bucket = null)
        {
            this.Identity = identity;
            this.Amount   = amount;
            this.Bucket   = bucket;
        }

        [JsonProperty(Required = Required.Always)]
        public string Identity { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Amount { get; set; }

        public string Bucket { get; set; }
    }
}
