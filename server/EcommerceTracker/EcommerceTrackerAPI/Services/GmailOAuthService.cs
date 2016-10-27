using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EcommerceTrackerAPI.Models;
using Newtonsoft.Json;

namespace EcommerceTrackerAPI.Services
{
    public class GmailOAuthService: IGmailOAuthService
    {
        private readonly ClientSecrets _cs;
        private readonly string[] _scopes = { 
            "https://www.googleapis.com/auth/userinfo.email",
            "https://www.googleapis.com/auth/userinfo.profile",
            "https://www.googleapis.com/auth/gmail.readonly"
        };
        private static readonly HttpClient Client = new HttpClient();
        private readonly string _clientSecretsPath = HttpContext.Current.Server.MapPath("~/client_secret.json");
        private const string TokenRequestUri = "https://www.googleapis.com/oauth2/v4/token";

        public GmailOAuthService()
        {
            _cs = ReadClientSecrets(_clientSecretsPath);
        }

        public AuthorizationUrl GetAuthorizationUrl()
        {
            return new AuthorizationUrl(BuildAuthorizationUrl());
        }

        public GmailOAuthAccessTokens GetAccessTokensFromOAuth(string authCode)
        {
            return ExchangeCodeForAccessTokens(authCode).Result;
        }

        public string GetAntiForgeryToken()
        {
            return GenerateRandomCryptoString(30);
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

        private async Task<GmailOAuthAccessTokens> ExchangeCodeForAccessTokens(string authCode)
        {
            var formValues = new Dictionary<string, string>
            {
                { "code", authCode },
                { "client_id", _cs.web.client_id },
                { "client_secret", _cs.web.client_secret },
                { "redirect_uri", _cs.web.redirect_uris[0] },
                { "grant_type", "authorization_code" }
            };
            var encodedContent = new FormUrlEncodedContent(formValues);
            var response = Client.PostAsync(TokenRequestUri, encodedContent).Result;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GmailOAuthAccessTokens>(json);
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
