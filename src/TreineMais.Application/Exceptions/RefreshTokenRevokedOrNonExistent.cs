using TreineMais.Application.Model;

namespace TreineMais.Application.Exceptions;

public class RefreshTokenRevokedOrNonExistent : ValidationException
{
    public RefreshTokenRevokedOrNonExistent(string message)
        : base(message,
        [
            new ValidationError(
                "RefreshToken",
                message)
        ])
    {
    }
}