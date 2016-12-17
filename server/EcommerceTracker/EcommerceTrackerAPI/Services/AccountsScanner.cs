using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EcommerceTrackerAPI.Models;
using Hangfire;

namespace EcommerceTrackerAPI.Services
{
    public class AccountsScanner
    {
        public void Run()
        {
            List<int> gmailAccountIds;
            //List<int> imapAccountIds;
            using (var db = new ApplicationDbContext())
            {
                gmailAccountIds = db.EmailAccounts.OfType<GmailAccount>().Select(a => a.ID).ToList();
                //imapAccountIds = db.EmailAccounts.OfType<ImapAccount>().Select(a => a.ID).ToList();
            }
            if (gmailAccountIds.Count > 0)
            {
                foreach (var gmailAccountId in gmailAccountIds)
                {
                    BackgroundJob.Enqueue<GmailScanner>(x => x.Scan(gmailAccountId));
                }
            }
            /*if (imapAccountIds.Count > 0)
            {
                foreach (var imapAccountId in imapAccountIds)
                {
                    
                }
            }*/
        }
    }
}