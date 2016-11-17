using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using EcommerceTrackerAPI.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Newtonsoft.Json;
using ClientSecrets = EcommerceTrackerAPI.Models.ClientSecrets;

namespace EcommerceTrackerAPI.Services
{
    public class GmailOAuthService: IGmailOAuthService
   { 
        private static GoogleClientSecrets _clientSecrets;
        private const string ApplicationName = "Personal Finance Manager";

        private readonly ClientSecrets _cs;
        private readonly string[] _scopes = { 
            "https://www.googleapis.com/auth/userinfo.email",
            "https://www.googleapis.com/auth/userinfo.profile",
            "https://www.googleapis.com/auth/gmail.readonly"
        };
        private static readonly string ClientSecretsPath = HttpContext.Current.Server.MapPath("~/client_secret.json");
        private const string RedirectUrl = "http://localhost:3000/authorize";

        public GmailOAuthService()
        {
            _cs = ReadClientSecrets(ClientSecretsPath);
            _clientSecrets = GetClientSecrets();
        }

        public TokenResponse GetTokenResponse(string code)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = _clientSecrets.Secrets,
                Scopes = new[] { GmailService.Scope.GmailReadonly }
            });
            return flow.ExchangeCodeForTokenAsync("", code, RedirectUrl, CancellationToken.None).Result;
        }

        public bool RefreshToken(ref TokenResponse token)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = _clientSecrets.Secrets,
                Scopes = new [] { GmailService.Scope.GmailReadonly }
            });

            var credential = new UserCredential(flow, "me", token);
            return credential.RefreshTokenAsync(CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets a Gmail service object for making authorized API calls to Google+ endpoints.
        /// </summary>
        /// <param name="credentials">The OAuth 2 credentials to use to authorize the client.</param>
        /// <returns>
        /// A <see cref="GmailService">GmailService</see>"/> object for API calls authorized to the
        /// user who corresponds with the credentials.
        /// </returns>
        /// https://gusclass.com/blog/2014/04/16/how-to-oauth-2-0-flows-using-the-google-net-api-client-libraries-1-7-in-c/
        public GmailService GetGmailService(TokenResponse credentials)
        {
            var flow = new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = _clientSecrets.Secrets,
                    Scopes = new[] { GmailService.Scope.GmailReadonly }
                });

            var credential = new UserCredential(flow, "me", credentials);

            return new GmailService(
                new BaseClientService.Initializer
                {
                    ApplicationName = ApplicationName,
                    HttpClientInitializer = credential
                });
        }

        public string GetAntiForgeryToken()
        {
            var token = GenerateRandomCryptoString(30);
            return token;
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

        /// <summary>Retrieves the Client Configuration from the server path.</summary>
        /// <returns>Client secrets that can be used for API calls.</returns>
        /// https://gusclass.com/blog/2014/04/16/how-to-oauth-2-0-flows-using-the-google-net-api-client-libraries-1-7-in-c/
        private static GoogleClientSecrets GetClientSecrets()
        {
            using (var stream = new FileStream(ClientSecretsPath, FileMode.Open, FileAccess.Read))
            {
                return GoogleClientSecrets.Load(stream);
            }
        }

        private string BuildAuthorizationUrl()
        {
            var parameters = new[]
            {
                $"scope={string.Join("%20", _scopes)}",
                $"redirect_uri={_cs.web.redirect_uris[0]}",
                "response_type=code",
                $"client_id={_cs.web.client_id}",
                "access_type=offline",
                "approval_prompt=force"
            };
            return $"{_cs.web.auth_uri}?{string.Join("&", parameters)}";
        }

        private static ClientSecrets ReadClientSecrets(string clientSecretPath)
        {
            using (var stream = new FileStream(clientSecretPath, FileMode.Open))
            using (var r = new StreamReader(stream))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<ClientSecrets>(json);
            }
        }
    }
}
