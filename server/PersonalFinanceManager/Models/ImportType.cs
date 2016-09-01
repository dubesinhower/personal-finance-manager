using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class ImportType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ImportRule> ImportRules { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}