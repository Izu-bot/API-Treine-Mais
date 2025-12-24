using System;

namespace TreineMais.Domain.Exceptions;

internal sealed class DomainException(string message) : Exception(message);
