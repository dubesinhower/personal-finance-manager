namespace EcommerceTrackerAPI.Domain.Entities
{
    public class Email
    {
        public long ID { get; set; }
        public int EmailAccountID { get; set; }
    }
    
    public class GmailMessage : Email
    {
        public string GmailMessageID { get; set; }
    }
}