using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Extensions;

public static class ResponseExtensions
{
    public static ActionResult ToResponse(this Error error)
    {
        var statusCode = error.Type switch
        {
            Error.ErrorType.Conflict => StatusCodes.Status409Conflict,
            Error.ErrorType.NotFound => StatusCodes.Status404NotFound,
            Error.ErrorType.Failure => StatusCodes.Status500InternalServerError,
            Error.ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return new ObjectResult(error)
        {
            StatusCode = statusCode
        };
    }
}