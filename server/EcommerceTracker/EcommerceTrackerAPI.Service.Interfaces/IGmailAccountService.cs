using EcommerceTrackerAPI.Domain.ResourceModels;
using Google.Apis.Auth.OAuth2.Flows;

namespace EcommerceTrackerAPI.Service.Interfaces
{
    public interface IGmailAccountService
    {
        void CreateGmailAccountFromAuthorizationCode(string code, string userID);
        void RemoveGmailAccount(int gmailAccountID);
    }
}