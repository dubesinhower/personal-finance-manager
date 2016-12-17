using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTrackerAPI.Domain.Entities;

namespace EcommerceTrackerAPI.Domain.Interfaces
{
    public interface IGmailMessageRepository
    {
        IEnumerable<GmailMessage> GetAll();
        IEnumerable<GmailMessage> GetByUser(string userID);
        void Add(GmailMessage message);
        void AddRange(IEnumerable<GmailMessage> messages);
        void Remove(int messageID);
        void Save();
    }
}
