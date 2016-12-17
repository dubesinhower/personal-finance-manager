using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using EcommerceTrackerAPI.Domain.ResourceModels;
using EcommerceTrackerAPI.Service.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;

namespace EcommerceTrackerAPI.Services
{
    public class GmailAPIService : IGmailAPIService
    {
        private readonly GoogleClientSecrets _googleClientSecrets;
        private const string ApplicationName = "Personal Finance Manager";
        private readonly string[] _gmailScopes;
        private readonly string _redirectURI;

        public GmailAPIService(
            string clientSecretsPath,
            string[] gmailScopes,
            string redirectURI)
        {
            _googleClientSecrets = GetClientSecrets(clientSecretsPath);
            _gmailScopes = gmailScopes;
            _redirectURI = redirectURI;
        }

        public OAuthURIDataResource GetOAuthURIData()
        {
            return new OAuthURIDataResource
            {
                ClientID = _googleClientSecrets.Secrets.ClientId,
                RedirectURI = _redirectURI,
                Scopes = _gmailScopes,
                SecurityToken = GenerateRandomCryptoString(30)
            };
        }

        public List<Message> GetAllMessages(TokenResponse token)
        {
            return GetMessages(token, null);
        }

        public string GetEmailAddress(TokenResponse token)
        {
            using (var gmailService = GetGmailService(token))
            {
                var profile = gmailService.Users.GetProfile("me").Execute();
                return profile.EmailAddress;
            }
        }

        public List<Message> GetMessages(TokenResponse token, string searchOperator)
        {
            var result = new List<Message>();
            using (var service = GetGmailService(token))
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
                    catch (Exception)
                    {
                        return null;
                    }

                } while (!string.IsNullOrEmpty(request.PageToken));
            }
            return result;
        }

        public TokenResponse ExchangeCodeForToken(string code)
        {
            var flow = GetFlow();

            TokenResponse token;
            try
            {
                token = flow.ExchangeCodeForTokenAsync("", code, _redirectURI, CancellationToken.None).Result;
            }
            catch (AggregateException)
            {
                return null;
            }
            return token;
        }

        /// <summary>Retrieves the Client Configuration from the server path.</summary>
        /// <returns>Client secrets that can be used for API calls.</returns>
        /// https://gusclass.com/blog/2014/04/16/how-to-oauth-2-0-flows-using-the-google-net-api-client-libraries-1-7-in-c/
        private static GoogleClientSecrets GetClientSecrets(string clientSecretsPath)
        {
            using (var stream = new FileStream(clientSecretsPath, FileMode.Open, FileAccess.Read))
            {
                return GoogleClientSecrets.Load(stream);
            }
        }

        private GoogleAuthorizationCodeFlow GetFlow()
        {
            return new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = _googleClientSecrets.Secrets,
                Scopes = new[]
                {
                    GmailService.Scope.GmailReadonly
                }
            });
        }

        /// <summary>
        /// Gets a Gmail service object for making authorized API calls to Google+ endpoints.
        /// </summary>
        /// <param name="token">The OAuth 2 credentials to use to authorize the client.</param>
        /// <returns>
        /// A <see cref="GmailService">GmailService</see>"/> object for API calls authorized to the
        /// user who corresponds with the credentials.
        /// </returns>
        /// https://gusclass.com/blog/2014/04/16/how-to-oauth-2-0-flows-using-the-google-net-api-client-libraries-1-7-in-c/
        public GmailService GetGmailService(TokenResponse token)
        {
            var flow = GetFlow();

            var credential = new UserCredential(flow, "me", token);

            return new GmailService(
                new BaseClientService.Initializer
                {
                    ApplicationName = ApplicationName,
                    HttpClientInitializer = credential
                });
        }

        private static string GenerateRandomCryptoString(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[size];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
