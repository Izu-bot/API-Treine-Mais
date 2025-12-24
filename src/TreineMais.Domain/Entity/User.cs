using TreineMais.Domain.Exceptions;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class User
{ 
    public Guid Id { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Profile Profile { get; private set; } = null!;
    public Login Login { get; private set; } = null!;
    public bool EmailConfirmed { get; private set; }
    public string? EmailConfirmedToken { get; private set; }
    public DateTime? EmailConfirmationTokenExpiresAt { get; private set; }
    public ICollection<Exercise> Exercises { get; private set; } = new List<Exercise>();
    public ICollection<Training> Trainings { get; private set; } = new List<Training>();
    public ICollection<Routine> Routines { get; private set; } = new List<Routine>();
    
    private User() { }

    public User(Login login)
    {
        Id = Guid.CreateVersion7();
        Login = login ??  throw new ArgumentNullException(nameof(login));
        EmailConfirmed = false;
        GenerateEmailConfirmationToken();
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }
    
    public void ActivateUser() => Active = true;
    public void DeactivateUser() => Active = false;
    
    public void UpdateProfile(Profile profile)
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
            throw new DomainException("E-mail já confirmado.");
        
        if (EmailConfirmedToken != token || EmailConfirmationTokenExpiresAt < DateTime.UtcNow)
            throw new DomainException("Token inválido ou expirado.");
        
        EmailConfirmed = true;
        EmailConfirmedToken = null!;
    }

    private void GenerateEmailConfirmationToken()
    {
        EmailConfirmedToken = Guid.NewGuid().ToString("N");
        EmailConfirmationTokenExpiresAt = DateTime.UtcNow.AddHours(24);
    }

    public void UpdateProfileName(string newName) => Profile.UpdateName(newName);
    public void UpdateProfileHeight(Height newHeight) => Profile.UpdateHeight(newHeight);
    public void UpdateProfileWeight(Weight newWeight) => Profile.UpdateWeight(newWeight);
    public void UpdateProfileGoals(string newGoals) =>  Profile.UpdateGoals(newGoals);
}