using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Routine> Routines { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}