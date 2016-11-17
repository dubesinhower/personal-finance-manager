using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceTrackerAPI.Models;
using Hangfire;

namespace EcommerceTrackerAPI.Services
{
    public class AccountsScanner : IAccountsScanner
    {
        public void Run()
        {
            List<GmailAccount> gmailAccounts;
            using (var db = new ApplicationDbContext())
            {
                gmailAccounts = db.EmailAccounts.OfType<GmailAccount>().ToList();
            }
            if (gmailAccounts.Count > 0)
            {
                foreach (var gmailAccount in gmailAccounts)
                {
                    BackgroundJob.Enqueue<GmailAccountScanner>(x => x.Scan(gmailAccount));
                }
            }
        }
    }
}