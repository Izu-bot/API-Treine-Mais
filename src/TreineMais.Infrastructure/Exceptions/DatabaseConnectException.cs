using System;

namespace TreineMais.Infrastructure.Exceptions;

internal class DatabaseConnectException(string message) : InfrastructureException(message);