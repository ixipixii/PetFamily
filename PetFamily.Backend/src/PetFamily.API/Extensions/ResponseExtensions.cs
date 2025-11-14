using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Response;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Extensions;

public static class ResponseExtensions
{
    public static ActionResult<T> ToResponse<T>(this Result<T, Error> result)
    {
        if(result.IsSuccess)
            return new OkObjectResult(Envelop.Ok(result.Value));
        
        var statusCode = result.Error.Type switch
        {
            Error.ErrorType.Conflict => StatusCodes.Status409Conflict,
            Error.ErrorType.NotFound => StatusCodes.Status404NotFound,
            Error.ErrorType.Failure => StatusCodes.Status500InternalServerError,
            Error.ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var envelope = Envelop.Error(result.Error);

        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    }
    
    public static ActionResult ToResponse(this UnitResult<Error> result)
    {
        if(result.IsSuccess)
            return new OkResult();
        
        var statusCode = result.Error.Type switch
        {
            Error.ErrorType.Conflict => StatusCodes.Status409Conflict,
            Error.ErrorType.NotFound => StatusCodes.Status404NotFound,
            Error.ErrorType.Failure => StatusCodes.Status500InternalServerError,
            Error.ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        var envelope = Envelop.Error(result.Error);

        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    }
}