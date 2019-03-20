using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NetCore.Core.Bases
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this BLResponse response)
        {
            var status = response.HasErrors ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this BLSingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.HasErrors)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this BLListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.HasErrors)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NoContent;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}
