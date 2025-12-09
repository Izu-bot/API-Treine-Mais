using System;
using MediatR;
using TreineMais.Application.DTO.User;

namespace TreineMais.Application.UseCase.CreateUser;

public record CreateUserCommand : IRequest<UserResponse>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Gender { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
    public float Height { get; init; }
    public float Weight { get; init; }
    public string Goals { get; init; } = string.Empty;
}
