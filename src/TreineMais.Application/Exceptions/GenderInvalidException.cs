using System;
using TreineMais.Application.Model;

namespace TreineMais.Application.Exceptions;

public class GenderInvalidException : ValidationException
{
    public GenderInvalidException(string value)
    : base(
        "Erro de validação.",
        [
            new ValidationError(
                field: "Gender",
                message: $"Gênero inválido: {value}"
            )
        ]
    )
    {
    }
}
