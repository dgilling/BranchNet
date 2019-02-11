using System.Net;
using System.Net.Http;
using BranchNet.Extensions;

namespace BranchNet.Models
{
    public class CreditQuery
    {
        public Transaction Transaction { get; set; }

        public Event Event { get; set; }

        public string Referrer { get; set; }

        public string Referee { get; set; }
    }
}