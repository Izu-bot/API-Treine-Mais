using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TreineMais.Infrastructure.Exceptions;

namespace TreineMais.Infrastructure.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        DotNetEnv.Env.Load("../TreineMais.API/.env");

        var connectionString = DotNetEnv.Env.GetString("ConnectionString__DefaultConnection")
        ?? throw new DatabaseConnectException("Erro: String de conexão não configurada corretamente, verificar o factory.");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}