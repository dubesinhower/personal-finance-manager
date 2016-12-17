using EcommerceTrackerAPI.Domain.Interfaces;
using EcommerceTrackerAPI.Service.Interfaces;
using Hangfire;

namespace EcommerceTrackerAPI.Services
{
    public class EmailAccountScannerService : IEmailAccountScannerService
    {
        private readonly IGmailAccountRepository _gmailAccountRepository;

        public EmailAccountScannerService(IGmailAccountRepository gmailAccountRepository)
        {
            _gmailAccountRepository = gmailAccountRepository;
        }

        public void ScanAllGmailAccounts()
        {
            var gmailAccounts = _gmailAccountRepository.GetAll();
            foreach (var gmailAccount in gmailAccounts)
            {
                BackgroundJob.Enqueue<GmailAccountScannerService>(
                    gmailAccountScanner => gmailAccountScanner.ScanForNewMessages(gmailAccount.ID));
            }
        }
    }
}
