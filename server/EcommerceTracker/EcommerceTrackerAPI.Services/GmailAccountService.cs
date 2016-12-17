using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceTrackerAPI.Domain.Entities;
using EcommerceTrackerAPI.Domain.Enums;
using EcommerceTrackerAPI.Domain.Interfaces;
using EcommerceTrackerAPI.Domain.ResourceModels;
using EcommerceTrackerAPI.Service.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;

namespace EcommerceTrackerAPI.Services
{
    public class GmailAccountService : IGmailAccountService
    {
        private readonly IGmailAPIService _gmailAPIService;
        private readonly IGmailAccountRepository _gmailAccountRepository;

        public GmailAccountService(
            IGmailAPIService gmailAPIService,
            IGmailAccountRepository gmailAccountRepository)
        {
            _gmailAPIService = gmailAPIService;
            _gmailAccountRepository = gmailAccountRepository;
        }

        public void CreateGmailAccountFromAuthorizationCode(string code, string userID)
        {
            var token = _gmailAPIService.ExchangeCodeForToken(code);
            if (token == null)
            {
                return;
            }

            var gmailAccountAddress = _gmailAPIService.GetEmailAddress(token);
            if (GmailAccountExists(gmailAccountAddress))
            {
                return;
            }

            var newGmailAccount = new GmailAccount
            {
                Name = gmailAccountAddress,
                UserID = userID,
                EmailType = EmailType.Gmail,
                Created = DateTime.Now,
                GmailEmailAddress = gmailAccountAddress,
                GmailAccessTokens = Mapper.Map<GmailAccessTokens>(token)
            };
            _gmailAccountRepository.Add(newGmailAccount);
            _gmailAccountRepository.Save();
        }

        public void RemoveGmailAccount(int gmailAccountID)
        {
            _gmailAccountRepository.Remove(gmailAccountID);
        }

        private bool GmailAccountExists(string gmailAccountAddress)
        {
            return _gmailAccountRepository.GetByGmailAddress(gmailAccountAddress) != null;
        }
    }
}
