using System;

namespace TreineMais.Infrastructure.Exceptions;

internal class InfrastructureException(string message) : Exception(message);
