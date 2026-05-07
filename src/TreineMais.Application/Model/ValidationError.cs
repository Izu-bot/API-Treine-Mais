namespace TreineMais.Application.Model;

public sealed class ValidationError
{
    public ValidationError(string field, string message)
    {
        Field = field;
        Message = message;
    }

    public string Field { get; } = default!;
    public string Message { get; } = default!;
}