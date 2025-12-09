using System;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.DTO.Profile;

public record ProfileResponse(
    string Name,
    string Gender,
    string BirthDate,
    float Height,
    float Weight,
    string? Goals
);