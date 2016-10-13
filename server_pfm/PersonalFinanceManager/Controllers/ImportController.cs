using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ImportController : ApiController
    {
        private PersonalFinanceManagerContext db = new PersonalFinanceManagerContext();

        // POST: api/Import
        [ResponseType(typeof(void))]
        public IHttpActionResult PostImport([FromUri]string filename)
        {

            return Ok();
        }
    }
}
