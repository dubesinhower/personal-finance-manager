using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{   
    public class ImportRule
    {
        public int  Id { get; set; }
        public string ColumnName { get; set; }
        public string TransactionPropertyName { get; set; }
        public bool MayContainCommas { get; set; }
    }
}