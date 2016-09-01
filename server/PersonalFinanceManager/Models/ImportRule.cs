using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace backend.Models
{   
    public class ImportRule
    {
        public int  ID { get; set; }
        public int ImportTypeID { get; set; }
        [Required]
        public string ColumnName { get; set; }
        [Required]
        public string TransactionPropertyName { get; set; }
        public bool MayContainCommas { get; set; }

        public virtual ImportType ImportType { get; set; }
    }
}