using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TreineMais.Application.DTO.Profile;
using TreineMais.Application.DTO.User;
using TreineMais.Application.UseCase.CreateUser;

namespace TreineMais.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapPost("/register", async ([FromBody] UserRequest request, [FromServices] IMediator _mediator) =>
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
        });
    }
}
