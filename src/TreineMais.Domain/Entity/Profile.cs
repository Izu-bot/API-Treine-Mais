using TreineMais.Domain.Exceptions;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class Profile
{
    private Profile()
    {
    }

    public Profile(Guid userId, string name, Gender? gender, DateTime? birthDate, Height? height, Weight? weight,
        string? goals)
    {
        UserId = userId;
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
        Height = height ?? throw new ArgumentNullException(nameof(height));
        Weight = weight ?? throw new ArgumentNullException(nameof(weight));
        Goals = goals ?? string.Empty;
    }

    public string Name { get; private set; } = string.Empty;
    public Guid UserId { get; private set; }
    public Gender? Gender { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public Height? Height { get; private set; }
    public Weight? Weight { get; private set; }
    public string Goals { get; private set; } = string.Empty;
    public User User { get; private set; } = null!;
    public DateTime? UpdatedAt { get; private set; }

    public void UpdateProfile(string? name, Height? height, Weight? weight, string? goals, DateTime? updatedAt)
    {
        Name = name ?? throw new ProfileException($"{nameof(name)} cannot be null.");
        Height = height ?? throw new ProfileException($"{nameof(height)} cannot be null.");
        Weight = weight ?? throw new ProfileException($"{nameof(weight)} cannot be null.");
        Goals = goals ?? string.Empty;

        UpdatedAt = updatedAt;
    }
}