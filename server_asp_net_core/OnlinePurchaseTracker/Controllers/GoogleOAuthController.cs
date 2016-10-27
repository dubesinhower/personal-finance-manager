using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlinePurchaseTracker.Models;
using OnlinePurchaseTracker.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlinePurchaseTracker.Controllers
{
    [Route("api/[controller]")]
    public class GoogleOAuthController : Controller
    {
        private readonly GoogleOAuthService _gos;

        public GoogleOAuthController(GoogleOAuthService gos)
        {
            _gos = gos;
        }

        // GET: api/googleoauth/authorizationurl
        [HttpGet("authorizationUrl")]
        public AuthorizationUrl GetAuthorizationUrl()
        {
            return new AuthorizationUrl(_gos.AuthorizationUrl);
        }

        [HttpPost("authorizationCode")]
        public IActionResult PostAuthorizationCode([FromBody]string authCode)
        {
            if (!_gos.LoadAccessTokens(authCode))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
