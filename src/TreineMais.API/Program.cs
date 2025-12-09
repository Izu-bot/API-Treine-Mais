
using TreineMais.API.Endpoints;
using TreineMais.Application;
using TreineMais.Infrastructure;

DotNetEnv.Env.Load("../../.env");
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.Run();