using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using AutoMapper;
using EcommerceTrackerAPI.Models;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Hangfire;
using Microsoft.Ajax.Utilities;
using Org.BouncyCastle.Crypto.Digests;

namespace EcommerceTrackerAPI.Services
{
    public class GmailScanner
    {
        private readonly IGmailOAuthService _gmailOAuthService;

        public GmailScanner(IGmailOAuthService gmailOAuthService)
        {
            _gmailOAuthService = gmailOAuthService;
        }

        public void Scan(int accountId)
        {
            using (var db = new ApplicationDbContext())
            {
                var account = 
                    db.EmailAccounts.OfType<GmailAccount>()
                        .Include(e => e.GmailAccessTokens)
                        .SingleOrDefault(e => e.ID == accountId);
                if (account == null)
                {
                    return;
                }

                var token = Mapper.Map<TokenResponse>(account.GmailAccessTokens);

                var lastScannedDate = account.LastScanned;
                var existingEmails =
                    db.Emails.OfType<GmailEmail>()
                        .Where(e => e.EmailAccountID == account.ID).ToList();

                List<Message> messages;
                if (lastScannedDate == null || !existingEmails.Any())
                {
                    messages = ListAllMessages(token);
                }
                else
                {
                    var hoursSinceLastScan = (DateTime.Now - lastScannedDate).Value.TotalHours;
                    var searchOperator = $"newer_than:{Math.Ceiling(hoursSinceLastScan)}h";
                    messages = ListMessages(token, searchOperator);
                }

                var existingMessageIds = existingEmails.Select(e => e.GmailMessageID);
                var newMessages = messages.FindAll(m => !existingMessageIds.Contains(m.Id));
                var newMessageIds = newMessages.Select(m => m.Id);

                var newEmails = newMessageIds.Select(messageId => new GmailEmail
                {
                    EmailAccountID = accountId, GmailMessageID = messageId
                }).ToList();

                db.Emails.AddRange(newEmails);
                account.LastScanned = DateTime.Now;
                db.SaveChanges();
            }
        }

        /*private IEnumerable<GmailEmail> ScanNewEmails(TokenResponse token, List<GmailEmail> existingEmails)
        {
            var newMessages = new List<Message>();
            if (!existingEmails.Any())
            {
                newMessages.AddRange(GetMessages(token, null));
            }
            else
            {
                DateTime? lastReceivedDate = null;
                if (existingEmails.Any())
                {
                    lastReceivedDate = existingEmails.OrderByDescending(e => e.Recieved).First().Recieved;
                }
                var messages = GetMessages(token, lastReceivedDate).ToList();
            }

            return 
        }*/

        private List<Message> ListMessages(TokenResponse token, string searchOperator)
        {
            var result = new List<Message>();
            using (var service = _gmailOAuthService.GetGmailService(token))
            {
                var request = service.Users.Messages.List("me");
                if (searchOperator != null)
                    request.Q = searchOperator;

                do
                {
                    try
                    {
                        var response = request.Execute();
                        result.AddRange(response.Messages);
                        request.PageToken = response.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Debug.Write("An error occurred: " + e.Message);
                    }

                } while (!string.IsNullOrEmpty(request.PageToken));
            }
            return result;
        } 

        private List<Message> ListAllMessages(TokenResponse token)
        {
            return ListMessages(token, null);
        }
    }
}