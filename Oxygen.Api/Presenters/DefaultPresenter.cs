using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Oxygen.Application.Results;
using Oxygen.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Oxygen.Api.Presenters
{
    public static class DefaultPresenter
    {
        public static async Task<IActionResult> Cast(Result result, HttpStatusCode statusCode)
        {

            if (result.Error.HasValue)
            {
                return result.Error.Value switch
                {
                    ErrorCode.NotFound => new NotFoundObjectResult(result),
                    ErrorCode.Business => new UnprocessableEntityObjectResult(result),
                    ErrorCode.Unauthorized => new UnauthorizedObjectResult(result),
                    ErrorCode.InternalError => new ObjectResult(result) { StatusCode = (int)HttpStatusCode.InternalServerError },
                    _ => new BadRequestObjectResult(result),
                };
            }
            else
            {
                return statusCode switch
                {
                    HttpStatusCode.OK => new OkObjectResult(result.Data),
                    HttpStatusCode.Created => new CreatedResult(string.Empty, result.Data),
                    HttpStatusCode.NoContent => new NoContentResult(),
                    _ => new OkResult()
                };
            }
        }

        
    }
}
