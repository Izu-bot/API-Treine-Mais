using System;
using TreineMais.Application.DTO.Profile;
using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.DTO.User;

public record UserRequest(string Email, string Password, ProfileRequest Profile);