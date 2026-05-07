using MediatR;
using TreineMais.Application.UseCase.Sync.DTOs;

namespace TreineMais.Application.UseCase.Sync;

public record SyncCommand(Guid UserId, SyncProfileDto Profile) : IRequest<SyncResult>;

public record SyncResult(bool Success, string? Message = null);