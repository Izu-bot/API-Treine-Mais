using Isopoh.Cryptography.Argon2;
using TreineMais.Application.Security;

namespace TreineMais.Infrastructure.Security;

public class HashPassword : IHashPassword
{
    public bool VerifyPassword(string plain, string hash)
    {
        try
        {
            return Argon2.Verify(plain, hash);
        }
        catch(Exception ex)
        {
            throw new ($"Erro ao tentar verificar a senha: {ex.Message}");
        }
    }

    string IHashPassword.HashPassword(string password)
        => Argon2.Hash(password);


}
