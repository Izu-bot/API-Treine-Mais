using MediatR;
using Microsoft.AspNetCore.Mvc;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.DTO.User;
using TreineMais.Application.UseCase.ConfirmEmail;
using TreineMais.Application.UseCase.ConfirmRefreshToken;
using TreineMais.Application.UseCase.CreateUser;
using TreineMais.Application.UseCase.LoginUser;
using TreineMais.Application.UseCase.LogoutUser;

namespace TreineMais.API.Endpoints;

internal static class AuthEndpoints
{
    internal static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/register", CreateAccount);
        group.MapGet("/confirm-email", ConfirmEmail);
        group.MapPost("/login", Login);
        group.MapPost("/refresh", Refresh);
        group.MapPost("/logout", Logout);

        return app;
    }

    private static async Task<IResult> CreateAccount(
        [FromBody] UserRequest request,
        [FromServices] IMediator mediator
    )
    {
        var command = new CreateUserCommand
        {
            Email = request.Email,
            Password = request.Password,
            Name = request.Profile.Name,
            Gender = request.Profile.Gender,
            BirthDate = request.Profile.BirthDate,
            Height = request.Profile.Height,
            Weight = request.Profile.Weight,
            Goals = request.Profile.Goals!
        };

        var result = await mediator.Send(command);
        return Results.Created($"users/{result.UserId}", result);
    }

    private static async Task<IResult> ConfirmEmail(
        [FromQuery] string token,
        [FromServices] ConfirmEmailHandler handler
    )
    {
        await handler.ExecuteAsync(new ConfirmEmailCommand(token));
        return Results.Ok("E-mail confirmado.");
    }

    private static async Task<IResult> Login(
        [FromBody] AuthRequest request,
        [FromServices] IMediator mediator
    )
    {
        var command = new LoginUserCommand
        {
            Email = request.Email,
            Password = request.Password
        };

        var result = await mediator.Send(command);

        Dictionary<string, string> tokens = new()
        {
            {"AccessToken", result.AccessToken},
            {"RefreshToken", result.RefreshToken}
        };

        return Results.Ok(tokens);
    }

    private static async Task<IResult> Refresh(
        [FromBody] RefreshTokenCommand command,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    private static async Task<IResult> Logout(
        [FromBody] LogoutUserCommand command,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }
}
