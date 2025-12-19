using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprache;
using TreineMais.Application.DTO.Profile;
using TreineMais.Application.DTO.User;
using TreineMais.Application.UseCase.CreateUser;

namespace TreineMais.API.Endpoints;

internal static class AuthEndpoints
{
    internal static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/register", CreateAccount);

        return app;
    }

    private static async Task<IResult> CreateAccount(
        [FromBody] UserRequest request,
        [FromServices] IMediator _mediator
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

        var result = await _mediator.Send(command);
        return Results.Created($"users/{result.UserId}", result);
    }
}
