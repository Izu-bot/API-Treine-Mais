using System;
using MediatR;
using TreineMais.Application.DTO.User;

namespace TreineMais.Application.UseCase.ConfirmEmail;

public record ConfirmEmailCommand(string Token);
