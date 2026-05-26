namespace TreineMais.Application.UseCase.Sync.DTOs;

public record SyncProfileDto(
    string Name,
    float Height,
    float Weight,
    string? Goals,
    DateTime? UpdatedAt);