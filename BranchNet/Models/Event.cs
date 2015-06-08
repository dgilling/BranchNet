using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BranchNet.Extensions;

namespace BranchNet.Models
{

    public class Event
    {
        public string Name { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}