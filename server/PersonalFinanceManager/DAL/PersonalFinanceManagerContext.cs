using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL
{
    public class PersonalFinanceManagerContext : IdentityDbContext<ApplicationUser>
    {
        public PersonalFinanceManagerContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
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