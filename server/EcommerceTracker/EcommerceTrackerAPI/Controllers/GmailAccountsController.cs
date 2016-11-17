using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using EcommerceTrackerAPI.Models;
using EcommerceTrackerAPI.Services;
using Google.Apis.Gmail;
using Google.Apis.Gmail.v1;
using Google.Apis.Util;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceTrackerAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/GmailAccounts")]
    public class GmailAccountsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();  
        private readonly IGmailOAuthService _gos;

        // Autofac needs parameterless constructor
        public GmailAccountsController() { }

        public GmailAccountsController(IGmailOAuthService gos)
        {
            _gos = gos;
        }

        [Route("AntiForgeryToken")]
        [HttpGet]
        public IHttpActionResult GetAntiForgeryToken()
        {
            return Ok(_gos.GetAntiForgeryToken());
        }

        [ResponseType(typeof(GmailAccount))]
        public IHttpActionResult PostGmailAccount([FromBody]string authCode)
        {
            var token = _gos.GetTokenResponse(authCode);

            var gmailService = _gos.GetGmailService(token);
            var profile = gmailService.Users.GetProfile("me").Execute();

            var userID = User.Identity.GetUserId();
            var emailType = _db.EmailTypes.Single(ea => ea.Description == "Gmail");

            var gmailAccount = _db.EmailAccounts.Add(new GmailAccount
            {
                Name = profile.EmailAddress,
                UserID = userID,
                EmailType = emailType,
                GmailAccessTokens = Mapper.Map<GmailAccessTokens>(token)
            });
            _db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = gmailAccount.ID }, gmailAccount);
        }
    }
}
