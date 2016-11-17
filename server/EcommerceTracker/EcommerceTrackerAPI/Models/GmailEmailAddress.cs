using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EcommerceTrackerAPI.Models
{
    public class GmailEmailAddress
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }
    }
}