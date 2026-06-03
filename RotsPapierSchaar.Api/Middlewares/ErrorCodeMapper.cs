using RotsPapierSchaar.Application.ResultPattern;

namespace RotsPapierSchaar.Api.Middlewares;

public static class ErrorCodeMapper
{
    public static int ToStatusCode(ErrorCode errorCode)
    {
        return errorCode switch
        {
            ErrorCode.ValidationError => StatusCodes.Status400BadRequest,
            ErrorCode.InvalidOperation => StatusCodes.Status400BadRequest,
            _ => throw new InvalidOperationException($"Geen HTTP status gevonden voor ErrorCode '{errorCode}'.")
        };
    }
}
