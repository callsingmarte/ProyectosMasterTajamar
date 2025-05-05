using Amazon.CognitoIdentityProvider.Model;

namespace Publicaciones.Interfaces
{
    public interface ICognitoService
    {
        Task<AuthenticationResultType?> LoginUserAsync(string email, string password);
        Task<bool> RegisterUserAsync(string email, string password);
        Task<bool> ConfirmEmailAsync(string email, string code);
    }
}
