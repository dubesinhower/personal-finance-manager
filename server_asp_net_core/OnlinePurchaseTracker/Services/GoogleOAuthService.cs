using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlinePurchaseTracker.Models;

namespace OnlinePurchaseTracker.Services
{
    public class GoogleOAuthService
    {
        public string AuthorizationUrl;

        private readonly ClientSecrets _cs;
        private readonly string[] _scopes = { 
            "https://www.googleapis.com/auth/userinfo.email",
            "https://www.googleapis.com/auth/userinfo.profile",
            "https://www.googleapis.com/auth/gmail.readonly"
        };
        private static readonly HttpClient Client = new HttpClient();
        private const string TokenRequestUri = "https://www.googleapis.com/oauth2/v4/token";
        private string _accessToken = null;

        public GoogleOAuthService(string clientSecretPath)
        {
            _cs = ReadClientSecrets(clientSecretPath);
            Init();
        }

        public bool LoadAccessTokens(string authCode)
        {
            var tokens = ExchangeCodeForAccessTokens(authCode).Result;
            if (tokens.access_token == null || tokens.refresh_token == null)
            {
                return false;
            }
            _accessToken = tokens.access_token;
            return true;
        }

        private void Init()
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
            AuthorizationUrl = $"{_cs.web.auth_uri}?{string.Join("&", parameters)}";
        }

        private async Task<AccessTokens> ExchangeCodeForAccessTokens(string authCode)
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
            return JsonConvert.DeserializeObject<AccessTokens>(json);
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
