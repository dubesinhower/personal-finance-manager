using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using backend.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace backend.Models
{
    public class PersonalFinanceManagerContext : IdentityDbContext<ApplicationUser>
    {
        public PersonalFinanceManagerContext() : base("DefaultConnection")
        {
        }

        public static PersonalFinanceManagerContext Create()
        {
            return new PersonalFinanceManagerContext();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ImportRule> ImportRules { get; set; }
        public DbSet<ImportType> ImportTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}