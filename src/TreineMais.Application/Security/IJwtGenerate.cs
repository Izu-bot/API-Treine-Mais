using TreineMais.Application.DTO.Auth;
using TreineMais.Domain.Entity;

namespace TreineMais.Application.Security;

public interface IJwtGenerate
{
    /// <summary>
    /// O parâmetro como o tipo de dado User parece fazer mais sentido aqui
    /// não vejo o porque de colocar um DTO como AuthRequest, para tratar
    /// ele no handler que efetua o login e gera o token parece ser mais
    /// complicado, posso estar errado em colocar o objeto User, porém é
    /// como ficará por enquanto 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    string GenerateJwt(User request);
}