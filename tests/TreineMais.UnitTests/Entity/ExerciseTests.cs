using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.UnitTests.Entity;

public class ExerciseTests
{
    [Fact]
    public void Constructor_CreateNewExercise_NotNull()
    {
        Exercise exercise = new(1, "Supino", "Supino com barra, inclinado 40°", new Category("Superiores"));
        Assert.NotNull(exercise);
    }

    [Fact]
    public void ShouldBePossible_ChangeProperties()
    {
        Exercise exercise = new(1, "Supino", "Supino com barra, inclinado 40°", new Category("Superiores"));

        string newName = "Agachamento";
        string newDescription = "Agachamento no smith";
        Category newCategory = new("Inferiores");
        
        exercise.UpdateName(newName);
        exercise.UpdateDescription(newDescription);
        exercise.UpdateCategory(newCategory);
        
        Assert.Equal(newName, exercise.Name);
        Assert.Equal(newDescription, exercise.Description);
        Assert.Equal(newCategory, exercise.Category);
    }
}