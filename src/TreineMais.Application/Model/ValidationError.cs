using System;

namespace TreineMais.Application.Model;

public sealed class ValidationError
{
    public string Field { get; } = default!;
    public string Message { get; } = default!;

    public ValidationError(string field, string message)
    {
        Field = field;
        Message = message;
    }
}
