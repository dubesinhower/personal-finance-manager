namespace EcommerceTrackerAPI.Domain.ResourceModels
{
    public class OAuthURIDataResource
    {
        public string[] Scopes { get; set; }
        public string RedirectURI { get; set; }
        public string ClientID { get; set; }
        public string SecurityToken { get; set; }
    }
}
