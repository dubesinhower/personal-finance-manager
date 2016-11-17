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

namespace EcommerceTrackerAPI.Controllers
{
    public class ImapSettingsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly IImapService _ims;

        // Autofac needs parameterless constructor
        public ImapSettingsController() { }

        public ImapSettingsController(IImapService ims)
        {
            _ims = ims;
        }

        // GET: api/ImapSettings
        public IQueryable<ImapSettings> GetImapSettings()
        {
            return _db.ImapSettings;
        }

        // GET: api/ImapSettings/5
        [ResponseType(typeof(ImapSettings))]
        public IHttpActionResult GetImapSettings(int id)
        {
            var imapSettings = _db.ImapSettings.Find(id);
            if (imapSettings == null)
            {
                return NotFound();
            }

            return Ok(imapSettings);
        }

        // PUT: api/ImapSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImapSettings(int id, ImapSettings imapSettings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imapSettings.Id)
            {
                return BadRequest();
            }

            _db.Entry(imapSettings).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImapSettingsExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ImapSettings
        [ResponseType(typeof(ImapSettings))]
        public IHttpActionResult PostImapSettings(AddSettingsBindingModel settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_ims.TestConnection(settings.Connection) || !_ims.TestCredentials(settings.Connection, settings.Login))
                return BadRequest();

            // _db.ImapSettings.Add(settings);
            // _db.SaveChanges();

            return Ok();
            // return CreatedAtRoute("DefaultApi", new { id = imapSettings.Id }, imapSettings);
        }

        // DELETE: api/ImapSettings/5
        [ResponseType(typeof(ImapSettings))]
        public IHttpActionResult DeleteImapSettings(int id)
        {
            var imapSettings = _db.ImapSettings.Find(id);
            if (imapSettings == null)
            {
                return NotFound();
            }

            _db.ImapSettings.Remove(imapSettings);
            _db.SaveChanges();

            return Ok(imapSettings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImapSettingsExists(int id)
        {
            return _db.ImapSettings.Count(e => e.Id == id) > 0;
        }
    }
}