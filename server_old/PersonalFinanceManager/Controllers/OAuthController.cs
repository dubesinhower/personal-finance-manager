using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Gmail.v1;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Controllers
{
    [RoutePrefix("api/oauth")]
    public class OAuthController : ApiController
    {
        [Route("authorization")]
        public IHttpActionResult PostAuthorization([FromBody]string authCode)
        {
            
            Console.WriteLine(authCode);
            return Ok();
        }
    }
}
