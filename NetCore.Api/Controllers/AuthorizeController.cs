using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorizeController : ApiController
    {
        public AuthorizeController(ILogger<AuthorizeController> logger) : base(logger)
        {
        }

        [HttpGet]
        [Authorize]
        public string Protected()
        {
            return "Only if you have a valid token!";
        }
    }
}