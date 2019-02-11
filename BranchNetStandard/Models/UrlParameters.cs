using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BranchNet.Extensions;
using BranchNet.Constants;

namespace BranchNet.Models
{
    public class UrlParameters<T> : BaseAuthenticatedPayload where T : UrlDataParameters
    {
        public T Data  { get; set; }

        public string Alias { get; set; }

        public UrlType Type { get; set; }

        public int Duration { get; set; }

        public string Identity { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string Campaign { get; set; }

        public string Feature { get; set; }

        public string Channel { get; set; }

        public string Stage { get; set; }
    }
}
