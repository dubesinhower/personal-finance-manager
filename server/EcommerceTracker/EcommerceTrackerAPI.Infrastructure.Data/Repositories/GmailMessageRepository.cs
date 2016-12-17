using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTrackerAPI.Domain.Entities;
using EcommerceTrackerAPI.Domain.Interfaces;
using EcommerceTrackerAPI.Infrastructure.Data.DbContext;

namespace EcommerceTrackerAPI.Infrastructure.Data.Repositories
{
    public class GmailMessageRepository : IGmailMessageRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<GmailMessage> GetAll()
        {
            return _context.Emails.OfType<GmailMessage>();
        }

        public IEnumerable<GmailMessage> GetByUser(string userID)
        {

            return _context.Emails.OfType<GmailMessage>().Where(gm => gm == emai);
        }

        public void Add(GmailMessage message)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<GmailMessage> messages)
        {
            throw new NotImplementedException();
        }

        public void Remove(int messageID)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
