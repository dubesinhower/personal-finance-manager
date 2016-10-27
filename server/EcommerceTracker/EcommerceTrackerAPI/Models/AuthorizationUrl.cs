namespace EcommerceTrackerAPI.Models
{
    public class AuthorizationUrl
    {
        public AuthorizationUrl(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}
