namespace TreineMais.Application.Exceptions;

internal sealed class NotFoundException(string message) : BusinessException(message);