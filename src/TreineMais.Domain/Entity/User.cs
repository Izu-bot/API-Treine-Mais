using TreineMais.Domain.Exceptions;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class User
{
    private User()
    {
    }

    public User(Login login)
    {
        Id = Guid.CreateVersion7();
        Login = login ?? throw new ArgumentNullException(nameof(login));
        EmailConfirmed = false;
        GenerateEmailConfirmationToken();
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Profile? Profile { get; private set; }
    public Login Login { get; private set; } = null!;
    public bool EmailConfirmed { get; private set; }
    public string? EmailConfirmedToken { get; private set; }
    public DateTime? EmailConfirmationTokenExpiresAt { get; private set; }
    public ICollection<Exercise> Exercises { get; private set; } = new List<Exercise>();
    public ICollection<Training> Trainings { get; private set; } = new List<Training>();
    public ICollection<Routine> Routines { get; private set; } = new List<Routine>();
    public ICollection<RefreshToken> RefreshTokens { get; private set; } = new List<RefreshToken>();
    public DateTime? UpdatedAt { get; private set; }

    public void ActivateUser()
    {
        Active = true;
    }

    public void DeactivateUser()
    {
        Active = false;
    }

    public void CreateProfile(Profile profile)
    {
        Profile = profile ?? throw new ArgumentNullException(nameof(profile));
    }

    public void UpdateLogin(Login login)
    {
        Login = login ?? throw new ArgumentNullException(nameof(login));
    }

    public void ConfirmEmail(string token)
    {
        if (EmailConfirmed)
            throw new UserException("E-mail já confirmado.");

        if (EmailConfirmedToken != token || EmailConfirmationTokenExpiresAt < DateTime.UtcNow)
            throw new UserException("Token inválido ou expirado.");

        EmailConfirmed = true;
        EmailConfirmedToken = null!;
    }

    private void GenerateEmailConfirmationToken()
    {
        EmailConfirmedToken = Guid.NewGuid().ToString("N");
        EmailConfirmationTokenExpiresAt = DateTime.UtcNow.AddHours(24);
    }

    public void UpdateProfile(Profile? profile, DateTime? updateFromMobile)
    {
        if (updateFromMobile < UpdatedAt) return;

        if (Profile is null)
            throw new UserException("Usuário não possui um perfil.");

        Profile.UpdateProfile(profile?.Name, profile?.Height, profile?.Weight, profile?.Goals, DateTime.UtcNow);
        UpdatedAt = DateTime.UtcNow;
    }
}