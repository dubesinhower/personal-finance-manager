using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using EcommerceTrackerAPI.Models;
using EcommerceTrackerAPI.Services;
using Google.Apis.Auth.OAuth2.Responses;
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
        private readonly IGmailOAuthService _googleOAuthService;

        public GmailAccountsController(IGmailOAuthService gos)
        {
            _googleOAuthService = gos;
        }

        [Route("AntiForgeryToken")]
        [HttpGet]
        public IHttpActionResult GetAntiForgeryToken()
        {
            return Ok(_googleOAuthService.GetAntiForgeryToken());
        }

        [ResponseType(typeof(GmailAccount))]
        public IHttpActionResult PostGmailAccount([FromBody]string authCode)
        {
            TokenResponse token;
            try
            {
                token = _googleOAuthService.GetTokenResponse(authCode);
            }
            catch (AggregateException e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }

            var gmailService = _googleOAuthService.GetGmailService(token);
            var profile = gmailService.Users.GetProfile("me").Execute();
            var emailAddress = new MailAddress(profile.EmailAddress);
            if (GmailAccountExists(emailAddress))
            {
                return Conflict();
            }

            var userID = User.Identity.GetUserId();
            var emailType = _db.EmailTypes.Single(ea => ea.Description == "Gmail");

            var gmailAccount = _db.EmailAccounts.Add(new GmailAccount
            {
                Name = emailAddress.User,
                UserID = userID,
                EmailType = emailType,
                Created = DateTime.Now,
                GmailEmailAddress = emailAddress.Address,
                GmailAccessTokens = Mapper.Map<GmailAccessTokens>(token)
            });
            _db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = gmailAccount.ID }, gmailAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GmailAccountExists(MailAddress emailAddress)
        {
            {
                return _db.EmailAccounts.OfType<GmailAccount>().Count(e => e.GmailEmailAddress == emailAddress.Address) > 0;
            }
        }
    }
}
