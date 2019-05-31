using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Core.Util;

namespace Pandora.NetCore.Identity.Controllers
{
    [Route("auth/v1/[controller]")]
    public class SocialController : ApiBaseController
    {
        public SocialController(ILogger<SocialController> logger) : base(logger)
        {
        }
    }
}