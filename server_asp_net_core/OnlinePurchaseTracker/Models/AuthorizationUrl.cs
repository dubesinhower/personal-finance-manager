using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePurchaseTracker.Models
{
    public class AuthorizationUrl
    {
        public AuthorizationUrl(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}
