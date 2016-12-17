using System.Collections.Generic;
using EcommerceTrackerAPI.Domain.Entities;
using EcommerceTrackerAPI.Domain.ResourceModels;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1.Data;

namespace EcommerceTrackerAPI.Service.Interfaces
{
    public interface IGmailAPIService
    {
        OAuthURIDataResource GetOAuthURIData();
        string GetEmailAddress(TokenResponse token);
        List<Message> GetAllMessages(TokenResponse token);
        List<Message> GetMessages(TokenResponse token, string searchOperator);
        TokenResponse ExchangeCodeForToken(string code);
    }
}
