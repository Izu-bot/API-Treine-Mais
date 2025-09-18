using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class Exercise
{
    public int  Id { get; private set; }
    public int UserId { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Category Category { get; private set; } = null!;
    
    private Exercise() { }

    public Exercise(int userId, string name, string description, Category category)
    {
        UserId = userId;
        Name = name;
        Description = description;
        Category = category;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be null or whitespace.");
        
        Name = name;
    }
    
    public void UpdateDescription(string? description) => Description = description ?? string.Empty;

    public void UpdateCategory(Category category) => Category = category ?? throw new InvalidOperationException("Category cannot be null.");
}