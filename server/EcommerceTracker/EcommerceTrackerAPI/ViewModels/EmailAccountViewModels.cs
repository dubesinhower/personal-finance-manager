using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceTrackerAPI.Models;

namespace EcommerceTrackerAPI.ViewModels
{
    public abstract class EmailAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual EmailType Type { get; set; }
    }

    public class GmailAccountViewModel : EmailAccountViewModel
    {
        public bool HasGmailOAuthTokens { get; set; }
    }
}