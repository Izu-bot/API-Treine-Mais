using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class Profile
{
    public string Name { get; private set; } = null!;
    public Gender Gender { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Height Height { get; private set; } = null!;
    public Weight Weight { get; private set; } = null!;
    public string Goals { get; private set; } =  null!;
    
    private Profile() { }

    public Profile(string name, Gender gender, DateTime birthDate, Height height, Weight weight, string goals)
    {
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
        Height = height ?? throw new ArgumentNullException(nameof(height));
        Weight = weight ?? throw new ArgumentNullException(nameof(weight));
        Goals = goals ?? string.Empty;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be null or whitespace.");
        
        Name = name;
    }

    public void UpdateHeight(Height height) => Height = height ?? throw new InvalidOperationException("Height cannot be null.");
    public void UpdateWeight(Weight weight) => Weight = weight ?? throw new InvalidOperationException("Weight cannot be null.");
    public void UpdateGoals(string goals) => Goals = goals ?? string.Empty;
}