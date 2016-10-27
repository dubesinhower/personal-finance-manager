using EcommerceTrackerAPI.Models;

namespace EcommerceTrackerAPI.Services
{
    public interface IGmailOAuthService
    {
        AuthorizationUrl GetAuthorizationUrl();
        string GetAntiForgeryToken();
        GmailOAuthAccessTokens GetAccessTokensFromOAuth(string authCode);
    }
}