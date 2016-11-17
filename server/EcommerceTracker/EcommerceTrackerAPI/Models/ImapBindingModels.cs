namespace EcommerceTrackerAPI.Models
{
    public class AddSettingsBindingModel
    {
        public int EmailAccountId { get; set; }
        public ImapConnection Connection { get; set; }
        public ImapLogin Login { get; set; }
    }
}