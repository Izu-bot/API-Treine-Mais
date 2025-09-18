using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.UnitTests.Entity;

public class UserTests
{
    [Fact]
    public void Constructor_WithNullProfile_ShouldThrowException()
    {
        Login? login = null;
        Profile? profile = null;

        Assert.Throws<ArgumentNullException>(() => new User(profile, login));
    }

    [Fact]
    public void Constructor_Filled_ShouldNotBeNull()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile,  login);
        
        Assert.NotNull(newUser);
    }

    [Fact]
    public void DisableUser_ShouldBeFalse_And_ActivateUser_ShouldBeTrue()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile,  login);
        
        newUser.DeactivateUser();
        Assert.False(newUser.Active);
        newUser.ActivateUser();
        Assert.True(newUser.Active);
    }

    [Fact]
    public void User_Can_UpdateProfile()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile, login);
        
        Weight newWeight = new(70.87f);
        Profile newProfile = new("Kauan", Gender.Male, DateTime.Now, height, newWeight, "Ficar mais rapido");
        newUser.UpdateProfile(newProfile);
        
        Assert.NotNull(newUser);
    }

    [Fact]
    public void User_Can_UpdateLogin()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile, login);

        
        Email newEmail = new("kauanmartins@email.com");
        Password newPassword = new("senha123");
        Login newLogin = new(newEmail, newPassword);
        newUser.UpdateLogin(newLogin);
        
        Assert.NotNull(newLogin);
    }

    [Fact]
    public void User_Can_UpdateName()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile, login);

        string newName = "Kauan Martins Cardoso";
        
        newUser.UpdateProfileName(newName);
        
        Assert.Equal(newName, newUser.Profile.Name);
    }

    [Fact]
    public void User_Can_UpdateHeight()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile, login);
        
        Height newHeight = new(1.75f);
        
        newUser.UpdateProfileHeight(newHeight);
        
        Assert.Equal(newHeight, newUser.Profile.Height);
    }

    [Fact]
    public void User_Can_UpdateWeight()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile, login);
        
        Weight newWeight =  new(70.87f);
        
        newUser.UpdateProfileWeight(newWeight);
        
        Assert.Equal(newWeight, newUser.Profile.Weight);
    }

    [Fact]
    public void User_Can_UpdateGoals()
    {
        Email email = new("kauan@email.com");
        Password password = new("password123");
        Login login = new(email, password);
        
        Height height = new(1.75f);
        Weight weight = new(80.5f);
        Profile profile = new("Kauan", Gender.Male, DateTime.Now, height, weight, "Ficar forte");
        
        User newUser = new(profile, login);

        string newGoals = "Quero ficar extremamente forte";
        
        newUser.UpdateProfileGoals(newGoals);
        
        Assert.Equal(newGoals, newUser.Profile.Goals);
    }
}
