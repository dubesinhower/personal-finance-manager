using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTrackerAPI.Domain.Entities;
using EcommerceTrackerAPI.Infrastructure.Data.EntityTypeConfiguration;
using EcommerceTrackerAPI.Infrastructure.Data.IdentityUser;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EcommerceTrackerAPI.Infrastructure.Data.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<EmailAccount> EmailAccounts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<GmailAccessTokens> GmailAccessTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GmailAccountTypeConfiguration().ToTable("GmailAccount"));
        }
    }
}
