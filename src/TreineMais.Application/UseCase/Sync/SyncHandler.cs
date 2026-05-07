using MediatR;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;

namespace TreineMais.Application.UseCase.Sync;

public class SyncHandler : IRequestHandler<SyncCommand, SyncResult>
{
    private readonly IUserRepository _userRepository;

    public SyncHandler(IUserRepository repository)
    {
        _userRepository = repository;
    }

    public async Task<SyncResult> Handle(SyncCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            return new SyncResult(false, "Usuário não existe");

        // Last-Write-Wins
        var newProfile = new Profile(
            user.Id,
            request.Profile.Name,
            user.Profile?.Gender,
            user.Profile?.BirthDate,
            request.Profile.Height,
            request.Profile.Weight,
            request.Profile.Goals
        );

        user.UpdateProfile(newProfile, request.Profile.UpdatedAt);

        await _userRepository.UpdateAsync(user);
        return new SyncResult(true);
    }
}