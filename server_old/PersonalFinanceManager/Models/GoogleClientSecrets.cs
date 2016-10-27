﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{
    public class GoogleClientSecrets
    {
        public string ClientId { get; set; }
        public string ProjectId { get; set; }
        public string AuthUri { get; set; }
        public string TokenUri { get; set; }
        public string AuthProviderX509CertUrl { get; set; }
        public string ClientSecret { get; set; }
        public string[] RedirectUris { get; set; }
    }
}