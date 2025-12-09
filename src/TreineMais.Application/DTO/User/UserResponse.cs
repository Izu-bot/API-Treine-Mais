using System;
using TreineMais.Application.DTO.Profile;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.DTO.User;

public record UserResponse(Guid UserId, string Email, ProfileResponse Profile);
