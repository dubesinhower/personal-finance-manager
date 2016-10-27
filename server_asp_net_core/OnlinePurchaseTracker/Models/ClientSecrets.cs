﻿using System.Collections.Generic;

namespace OnlinePurchaseTracker.Models
{
    public class ClientSecrets
    {
        public Web web { get; set; }
    }

    public class Web
    {
        public string client_id { get; set; }
        public string project_id { get; set; }
        public string auth_uri { get; set; }
        public string token_uri { get; set; }
        public string auth_provider_x509_cert_url { get; set; }
        public string client_secret { get; set; }
        public List<string> redirect_uris { get; set; }
    }
}