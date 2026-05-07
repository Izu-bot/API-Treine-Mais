namespace TreineMais.Application.Security;

public interface IHashPassword
{
    string HashPassword(string password);
    bool VerifyPassword(string plain, string hash);
}