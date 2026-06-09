using MediatR;
using TreineMais.Application.Responses.Auth;

namespace TreineMais.Application.UseCase.LogoutUser;

public class LogoutUserCommand : IRequest<LogoutResponse>
{
    public string RefreshToken { get; init; } = string.Empty;
}