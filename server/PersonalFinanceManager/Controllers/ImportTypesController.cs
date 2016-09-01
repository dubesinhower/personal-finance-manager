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
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Controllers
{
    public class ImportTypesController : ApiController
    {
        private PersonalFinanceManagerContext db = new PersonalFinanceManagerContext();

        // GET: api/ImportTypes
        public IQueryable<ImportType> GetImportTypes()
        {
            return db.ImportTypes.Include(i => i.ImportRules);
        }

        // GET: api/ImportTypes/5
        [ResponseType(typeof(ImportType))]
        public IHttpActionResult GetImportType(int id)
        {
            ImportType importType = db.ImportTypes.Find(id);
            if (importType == null)
            {
                return NotFound();
            }

            return Ok(importType);
        }

        // PUT: api/ImportTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImportType(int id, ImportType importType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != importType.Id)
            {
                return BadRequest();
            }

            db.Entry(importType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ImportTypes
        [ResponseType(typeof(ImportType))]
        public IHttpActionResult PostImportType(ImportType importType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImportTypes.Add(importType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = importType.Id }, importType);
        }

        // DELETE: api/ImportTypes/5
        [ResponseType(typeof(ImportType))]
        public IHttpActionResult DeleteImportType(int id)
        {
            ImportType importType = db.ImportTypes.Find(id);
            if (importType == null)
            {
                return NotFound();
            }

            db.ImportTypes.Remove(importType);
            db.SaveChanges();

            return Ok(importType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImportTypeExists(int id)
        {
            return db.ImportTypes.Count(e => e.Id == id) > 0;
        }
    }
}