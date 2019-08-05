using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Core.Utils;
using System.Linq;
using System.Net;

namespace Pandora.NetStandard.Core.Filters
{
    public class ValidModelStateFilter : ActionFilterAttribute 
    {
        protected readonly ILogger _logger;

        public ValidModelStateFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            _logger?.LogError("There was some validation errors", validationErrors);

            var response = BLResponse.GetVoidResponse(HttpStatusCode.BadRequest);
            response.Errors.AddRange(validationErrors);

            context.Result = new ObjectResult(response);
        }
    }
}
