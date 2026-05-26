namespace TreineMais.Domain.Exceptions;

internal sealed class UserException(string message) : DomainException(message);