using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserID { get; set; }
        public int ImportTypeID { get; set; }

        public virtual ImportType ImportType { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}