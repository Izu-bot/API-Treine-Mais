using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class User
{ 
    public Guid Id { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Profile Profile { get; private set; } = null!;
    public Login Login { get; private set; } = null!;

    private User() { }

    public User(Profile profile, Login login)
    {
        Id = Guid.CreateVersion7();
        Profile = profile ?? throw new ArgumentNullException(nameof(profile));
        Login = login ??  throw new ArgumentNullException(nameof(login));
        Active = true;
        CreatedAt = DateTime.Now;
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

    public void UpdateProfileName(string newName) => Profile.UpdateName(newName);
    public void UpdateProfileHeight(Height newHeight) => Profile.UpdateHeight(newHeight);
    public void UpdateProfileWeight(Weight newWeight) => Profile.UpdateWeight(newWeight);
    public void UpdateProfileGoals(string newGoals) =>  Profile.UpdateGoals(newGoals);
}