using APP_API.Models;

namespace APP_API.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}