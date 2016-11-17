using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Apis.Auth.OAuth2.Responses;

namespace EcommerceTrackerAPI.Models
{
    public class EmailAccount
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserID { get; set; }
        public int EmailTypeID { get; set; }

        public virtual EmailType EmailType { get; set; }
    }

    [Table("GmailAccounts")]
    public class GmailAccount : EmailAccount
    {
        public int? GmailAccessTokensID { get; set; }

        public virtual  GmailAccessTokens GmailAccessTokens { get; set; }
    }

    [Table("ImapAccounts")]
    public class ImapAccount : EmailAccount
    {
        public int? ImapSettingsID { get; set; }

        public virtual ImapSettings ImapSettings { get; set; }
    }

    public class EmailType
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}