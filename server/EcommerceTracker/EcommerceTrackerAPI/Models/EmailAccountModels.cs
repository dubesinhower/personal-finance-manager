using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceTrackerAPI.Models
{
    public abstract class EmailAccount
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public int EmailTypeId { get; set; }

        public virtual EmailType Type { get; set; }
    }

    [Table("GmailAccounts")]
    public class GmailAccount : EmailAccount
    {
        public int? GmailOAuthAccessTokensId { get; set; }
    }

    [Table("ImapAccounts")]
    public class ImapAccount : EmailAccount
    {
        public int? LoginCredentialsId { get; set; }
    }
}