using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL
{
    public partial class PersonalFinanceManagerContext
    {
        public int AddTransactionsFromCsv(int accountId)
        {
            var transactions = new List<Transaction>();
            Transactions.AddRange(transactions);
            return 0;
        }
    }
}