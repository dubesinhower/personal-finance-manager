using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }

        public virtual Account Account { get; set; }
    }
}