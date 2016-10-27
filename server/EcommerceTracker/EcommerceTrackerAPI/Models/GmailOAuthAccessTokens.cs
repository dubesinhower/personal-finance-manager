namespace EcommerceTrackerAPI.Models
{
    public class GmailOAuthAccessTokens
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
    }
}
