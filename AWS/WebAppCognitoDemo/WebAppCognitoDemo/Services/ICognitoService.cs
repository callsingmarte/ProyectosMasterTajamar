using Amazon.CognitoIdentityProvider.Model;

namespace WebAppCognitoDemo.Services
{
    public interface ICognitoService
    {
        Task<AuthenticationResultType?> LoginUserAsync(string email, string password);
        Task<bool> RegisterUserAsync(string email, string password);
        Task<bool> ConfirmEmailAsync(string email, string code);
    }
}
