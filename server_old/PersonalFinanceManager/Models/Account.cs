using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int ImportTypeId { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public virtual ImportType ImportType { get; set; }
    }
}