namespace EcommerceTrackerAPI.Service.Interfaces
{
    public interface IGmailAccountScannerService
    {
        void ScanForNewMessages(int accountID);
    }
}