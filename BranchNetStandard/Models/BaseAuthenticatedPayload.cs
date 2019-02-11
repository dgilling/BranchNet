using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using BranchNet.Extensions;

namespace BranchNet.Models
{
    public class BaseAuthenticatedPayload
    {
        [JsonProperty(Required = Required.Always)]
        internal string BranchKey { get; set; }

        [JsonProperty(Required = Required.Always)]
        internal string BranchSecret { get; set; }
    }
}
