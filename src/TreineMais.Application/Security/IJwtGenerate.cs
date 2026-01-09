using TreineMais.Application.DTO.Auth;

namespace TreineMais.Application.Security;

public interface IJwtGenerate
{
    string GenerateJwt(AuthRequest request);
}