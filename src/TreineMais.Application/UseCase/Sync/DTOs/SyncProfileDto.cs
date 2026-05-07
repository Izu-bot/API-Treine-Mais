using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.UseCase.Sync.DTOs;

public record SyncProfileDto(
    string Name,
    Height? Height,
    Weight? Weight,
    string? Goals,
    DateTime UpdatedAt);