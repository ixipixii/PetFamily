using PetFamily.Domain.Shared;

namespace PetFamily.API.Response;

public record Envelop
{
    public object? Result { get; }
    public string? ErrorCode { get; }
    public string? ErrorMessage { get; }
    public DateTime TimeGenerated { get; }

    public Envelop(object? result, Error? error)
    {
        Result = result;
        ErrorCode = error?.Code;
        ErrorMessage = error?.Message;
        TimeGenerated = DateTime.Now;
    }

    public static Envelop Ok(object? result) => new(result, null);
    public static Envelop Error(Error error) => new(null, error);
}