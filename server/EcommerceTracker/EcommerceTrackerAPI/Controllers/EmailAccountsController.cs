using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EcommerceTrackerAPI.Models;
using EcommerceTrackerAPI.Services;
using Hangfire;
using Microsoft.AspNet.Identity;

namespace EcommerceTrackerAPI.Controllers
{
    [Authorize]
    public class EmailAccountsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/EmailAccounts
        public IQueryable<EmailAccount> GetEmailAccounts()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();
            return _db.EmailAccounts.Where(ea => ea.UserID == userId).Include(ea => ea.EmailType);
        }

        // GET: api/EmailAccounts/5
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult GetEmailAccount(int id)
        {
            var emailAccount = _db.EmailAccounts.Find(id);
            if (emailAccount == null)
            {
                return NotFound();
            }

            return Ok(emailAccount);
        }

        // PUT: api/EmailAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmailAccount(int id, EmailAccount emailAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailAccount.ID)
            {
                return BadRequest();
            }

            _db.Entry(emailAccount).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailAccountExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmailAccounts
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult PostEmailAccount(EmailAccount emailAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.EmailAccounts.Add(emailAccount);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emailAccount.ID }, emailAccount);
        }

        // DELETE: api/EmailAccounts/5
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult DeleteEmailAccount(int id)
        {
            var emailAccount = _db.EmailAccounts.Include(e => e.EmailType).SingleOrDefault(e => e.ID == id);
            if (emailAccount == null)
            {
                return NotFound();
            }
            if (emailAccount.EmailType.Description == "Gmail")
            {
                var gmailAccount = (GmailAccount)_db.EmailAccounts.Find(id);
                var gmailAccessTokens = _db.GmailAccessTokens.Find(gmailAccount.GmailAccessTokensID);
                _db.GmailAccessTokens.Remove(gmailAccessTokens);
            }

            _db.EmailAccounts.Remove(emailAccount);
            _db.SaveChanges();

            return Ok(emailAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailAccountExists(int id)
        {
            return _db.EmailAccounts.Count(e => e.ID == id) > 0;
        }
    }
}