using System;
using FluentValidation;
using TreineMais.Application.Exception;
using TreineMais.Application.Model;

namespace TreineMais.Application.Helpers;

public static class ValidationHelper
{
    public static async Task ValidateAndThrowAsync<T>(IValidator<T> validator, T dto)
    {
        var result = await validator.ValidateAsync(dto);

        if (!result.IsValid)
        {
            var errors = result.Errors
                .Select(e => new ValidationError(
                    e.PropertyName,
                    e.ErrorMessage
                )
            );
            
            throw new FluentValidationException(errors);
        }
    }
}