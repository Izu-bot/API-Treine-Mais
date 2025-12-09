using System;
using BCrypt.Net;
using TreineMais.Application.Security;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Infrastructure.Security;

public class HashPassword : IHashPassword
{
    public bool VerifyPassword(string plain, string hash)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(plain, hash);
        }
        catch(BcryptAuthenticationException ex)
        {
            throw new BcryptAuthenticationException($"Erro ao tentar verificar a senha: {ex.Message}");
        }
    }

    string IHashPassword.HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);
}
