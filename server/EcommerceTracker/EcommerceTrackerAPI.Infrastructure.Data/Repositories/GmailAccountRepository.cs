using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EcommerceTrackerAPI.Domain.Entities;
using EcommerceTrackerAPI.Domain.Interfaces;
using EcommerceTrackerAPI.Infrastructure.Data.DbContext;

namespace EcommerceTrackerAPI.Infrastructure.Data.Repositories
{
    public class GmailAccountRepository : IGmailAccountRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public GmailAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GmailAccount> GetAll()
        {
            return _context.EmailAccounts.OfType<GmailAccount>();
        }

        public IEnumerable<GmailAccount> GetByUser(string userID)
        {
            return _context.EmailAccounts
                .OfType<GmailAccount>()
                .Where(ga => ga.UserID == userID);
        }

        public GmailAccount GetByID(int accountID)
        {
            return _context.EmailAccounts
                .OfType<GmailAccount>()
                .First(ga => ga.ID == accountID);
        }

        public GmailAccount GetByGmailAddress(string gmailAddress)
        {
            return _context.EmailAccounts
                .OfType<GmailAccount>()
                .First(ga => ga.GmailEmailAddress == gmailAddress);
        }

        public void Add(GmailAccount account)
        {
            _context.EmailAccounts.Add(account);
        }

        public void Update(GmailAccount account)
        {
            
        }

        public void Remove(int accountID)
        {
            var account = _context.EmailAccounts.OfType<GmailAccount>().First(ga => ga.ID == accountID);
            if (account != null) _context.EmailAccounts.Remove(account);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}