using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EcommerceTrackerAPI.Models;
using Google.Apis.Auth.OAuth2.Responses;

namespace EcommerceTrackerAPI.Services
{
    public class GmailAccountScanner : IGmailAccountScanner
    {
        private readonly IGmailOAuthService _gmailOAuthService;

        public GmailAccountScanner() { }

        public GmailAccountScanner(IGmailOAuthService gmailOAuthService)
        {
            _gmailOAuthService = gmailOAuthService;
        }

        public void Scan(GmailAccount account)
        {
            var token = Mapper.Map<TokenResponse>(account.GmailAccessTokens);
            var gmailService = _gmailOAuthService.GetGmailService(token);
            var messages = gmailService.Users.Messages.List("me").Execute();
        }
    }
}