using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceTrackerAPI.Models
{
    public class ImapSettings
    {
        [Key]
        public int Id {get; set; }
        public int ImapConnectionId { get; set; }
        public int? ImapLoginId { get; set; }
    }

    public class ImapConnection
    {
        [Key]
        public int Id {get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Range(0, 65535)]
        public int Port { get; set; }
    }

    public class ImapLogin
    {
        [Key]
        public int Id {get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}