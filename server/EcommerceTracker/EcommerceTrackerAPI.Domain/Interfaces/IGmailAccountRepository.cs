using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTrackerAPI.Domain.Entities;

namespace EcommerceTrackerAPI.Domain.Interfaces
{
    public interface IGmailAccountRepository
    {
        IEnumerable<GmailAccount> GetAll();
        IEnumerable<GmailAccount> GetByUser(string userID);
        GmailAccount GetByID(int accountID);
        GmailAccount GetByGmailAddress(string gmailAddress);
        void Add(GmailAccount account);
        void Update(GmailAccount account);
        void Remove(int accountID);
        void Save();
    }
}
