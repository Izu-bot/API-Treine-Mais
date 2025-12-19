using FluentValidation;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Model;

namespace TreineMais.Application.Exception;

public sealed class FluentValidationException : Exceptions.ValidationException
{
    public FluentValidationException(IEnumerable<ValidationError> errors) : base("Erros de validação", errors)
    {
    }
}