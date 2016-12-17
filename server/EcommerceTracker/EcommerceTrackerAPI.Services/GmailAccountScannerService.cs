using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EcommerceTrackerAPI.Domain.Entities;
using EcommerceTrackerAPI.Domain.Interfaces;
using EcommerceTrackerAPI.Service.Interfaces;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1.Data;

namespace EcommerceTrackerAPI.Services
{
    public class GmailAccountScannerService : IGmailAccountScannerService
    {
        private readonly IGmailAccountRepository _gmailAccountRepository;
        private readonly IGmailMessageRepository _gmailMessageRepository;
        private readonly IGmailAPIService _gmailAPIService;

        public GmailAccountScannerService(
            IGmailAccountRepository gmailAccountRepository, 
            IGmailMessageRepository gmailMessageRepository, 
            IGmailAPIService gmailAPIService)
        {
            _gmailAccountRepository = gmailAccountRepository;
            _gmailMessageRepository = gmailMessageRepository;
            _gmailAPIService = gmailAPIService;
        }

        public void ScanForNewMessages(int accountID)
        {
            var account = _gmailAccountRepository.GetByID(accountID);
            var existingMessageIDs = _gmailMessageRepository.GetAll().Select(e => e.GmailMessageID).ToList();
            var token = Mapper.Map<TokenResponse>(account.GmailAccessTokens);

            List<Message> newMessages;
            if (account.LastScanned == null || !existingMessageIDs.Any())
            {
                newMessages = _gmailAPIService.GetMessages(token, null).ToList();
            }
            else
            {
                var hoursSinceLastScan = (DateTime.Now - account.LastScanned).Value.TotalHours;
                var searchOperator = $"newer_than:{Math.Ceiling(hoursSinceLastScan)}h";
                newMessages = _gmailAPIService.GetMessages(token, searchOperator).ToList();
            }

            var gmailMessages = newMessages.Select(m => new GmailMessage
            {
                EmailAccountID = account.ID, GmailMessageID = m.Id
            }).ToList();

            _gmailMessageRepository.AddRange(gmailMessages);
            _gmailMessageRepository.Save();
            account.LastScanned = DateTime.Now;
            _gmailAccountRepository.Update(account);
            _gmailAccountRepository.Save();
        }
    }
}