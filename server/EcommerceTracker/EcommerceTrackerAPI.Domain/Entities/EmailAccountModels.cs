using System;
using EcommerceTrackerAPI.Domain.Enums;

namespace EcommerceTrackerAPI.Domain.Entities
{
    public class EmailAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public EmailType EmailType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastScanned { get; set; }
    }

    public class GmailAccount : EmailAccount
    {
        public string GmailEmailAddress { get; set; }
        public int? GmailAccessTokensID { get; set; }

        public virtual GmailAccessTokens GmailAccessTokens { get; set; }
    }
}