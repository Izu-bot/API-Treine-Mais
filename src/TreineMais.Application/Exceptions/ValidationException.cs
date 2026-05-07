using TreineMais.Application.Model;

namespace TreineMais.Application.Exceptions;

public abstract class ValidationException : BusinessException
{
    protected ValidationException(
        string message,
        IEnumerable<ValidationError> errors
    ) : base(message)
    {
        Errors = errors.ToList().AsReadOnly();
    }

    public IReadOnlyCollection<ValidationError> Errors { get; }
}