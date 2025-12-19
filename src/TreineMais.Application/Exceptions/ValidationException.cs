using System;
using TreineMais.Application.Model;

namespace TreineMais.Application.Exceptions;

public abstract class ValidationException : BusinessException
{
    public IReadOnlyCollection<ValidationError> Errors { get; }

    protected ValidationException(
        string message,
        IEnumerable<ValidationError> errors
    ) : base(message)
    {
        Errors = errors.ToList().AsReadOnly();
    }
}
