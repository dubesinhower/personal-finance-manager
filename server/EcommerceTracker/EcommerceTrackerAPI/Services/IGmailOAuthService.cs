using System.Threading.Tasks;
using EcommerceTrackerAPI.Models;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;

namespace EcommerceTrackerAPI.Services
{
    public interface IGmailOAuthService
    {
        string GetAntiForgeryToken();
        TokenResponse GetTokenResponse(string code);
        bool RefreshToken(ref TokenResponse token);
        GmailService GetGmailService(TokenResponse credentials);
    }
}