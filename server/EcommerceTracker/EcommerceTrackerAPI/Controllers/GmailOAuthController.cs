using System.Web.Http;
using System.Web.Http.Description;
using EcommerceTrackerAPI.Models;
using EcommerceTrackerAPI.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceTrackerAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/GmailOAuth")]
    public class GmailOAuthController : ApiController
    {
        private readonly IGmailOAuthService _gos;

        // Autofac needs parameterless constructor
        public GmailOAuthController() { }

        public GmailOAuthController(IGmailOAuthService gos)
        {
            _gos = gos;
        }

        // GET: api/googleoauth/authorizationurl
        [ResponseType(typeof(AuthorizationUrl))]
        [Route("AuthorizationUrl")]
        [HttpGet]
        public IHttpActionResult GetAuthorizationUrl()
        {
            return Ok(_gos.GetAuthorizationUrl());
        }

        [Route("AntiForgeryToken")]
        [HttpGet]
        public IHttpActionResult GetAntiForgeryToken()
        {
            return Ok(_gos.GetAntiForgeryToken());
        }
        
        public IHttpActionResult PostAuthorizationCode([FromBody]string authCode)
        {
            var tokens = _gos.GetAccessTokensFromOAuth(authCode);
            if (tokens == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
