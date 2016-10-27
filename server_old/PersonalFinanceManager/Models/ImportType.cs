using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{
    public class ImportType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ImportRule> ImportRules { get; set; }
    }
}