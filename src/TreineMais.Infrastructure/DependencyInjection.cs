using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreineMais.Application.Abstractions;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Infrastructure.Context;
using TreineMais.Infrastructure.Email;
using TreineMais.Infrastructure.Exceptions;
using TreineMais.Infrastructure.Persistence;
using TreineMais.Infrastructure.Security;

namespace TreineMais.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        DotNetEnv.Env.Load("../TreineMais.API/.env");

        var connectionString = configuration.GetConnectionString("CONNECTION_STRING")
        ?? DotNetEnv.Env.GetString("CONNECTION_STRING")
        ?? throw new DatabaseConnectException("Não foi possivel se conectar com o banco de dados.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IHashPassword, HashPassword>();
        services.AddSingleton<IJwtGenerate, JwtGenerate>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        
        services.AddSingleton<IEmailSender, SmtpEmailSender>();

        return services;
    }
}
