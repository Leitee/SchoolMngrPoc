using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Pandora.NetStandard.Core.Util
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this BLResponse response)
        {
            var status = response.HasError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this BLSingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.HasError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Data == null)
                status = HttpStatusCode.NotFound;

            response.ResponseCode = status;
            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this BLListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.HasError)
                status = HttpStatusCode.InternalServerError;
            else if (!response.Data.Any())
                response.ResponseCode = HttpStatusCode.NoContent;

            if (response.ResponseCode != HttpStatusCode.NoContent)
                response.ResponseCode = status;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}
