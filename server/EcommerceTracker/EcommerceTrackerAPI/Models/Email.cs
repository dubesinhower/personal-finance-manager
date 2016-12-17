using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Org.BouncyCastle.Math;

namespace EcommerceTrackerAPI.Models
{
    public class Email
    {
        public long ID { get; set; }
        public int EmailAccountID { get; set; }
    }

    [Table("GmailEmail")]
    public class GmailEmail : Email
    {
        [Required]
        public string GmailMessageID { get; set; }
    }
}