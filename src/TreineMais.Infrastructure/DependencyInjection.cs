using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Infrastructure.Context;
using TreineMais.Infrastructure.Persistence;
using TreineMais.Infrastructure.Security;

namespace TreineMais.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        DotNetEnv.Env.Load("../../.env");

        var connectionString = DotNetEnv.Env.GetString("ConnectionString__DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IHashPassword, HashPassword>();

        return services;
    }
}
