using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Publicaciones.Interfaces;
using Publicaciones.Models;
using System.Security.Cryptography;
using System.Text;

namespace Publicaciones.Services
{
    public class CognitoService : ICognitoService
    {
        private readonly IAmazonCognitoIdentityProvider? _provider;
        private readonly AwsCognitoSettings _cognitoSettings;

        public CognitoService(IAmazonCognitoIdentityProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _cognitoSettings = configuration.GetSection("AWS").Get<AwsCognitoSettings>();
        }

        private string GenerateSecretHash(string username)
        {
            var message = Encoding.UTF8.GetBytes(username + _cognitoSettings!.CognitoClientId);
            var key = Encoding.UTF8.GetBytes(_cognitoSettings.CognitoAppClientSecret!);

            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(message);
                return Convert.ToBase64String(hash);
            }
        }

        public async Task<bool> ConfirmEmailAsync(string email, string code)
        {
            var request = new ConfirmSignUpRequest
            {
                ClientId = _cognitoSettings.CognitoClientId,
                Username = email,
                ConfirmationCode = code,
                SecretHash = GenerateSecretHash(email)
            };

            try
            {
                var response = await _provider!.ConfirmSignUpAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<AuthenticationResultType?> LoginUserAsync(string email, string password)
        {
            var request = new AdminInitiateAuthRequest
            {
                UserPoolId = _cognitoSettings!.CognitoUserPoolId,
                ClientId = _cognitoSettings!.CognitoClientId,
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
                AuthParameters = new Dictionary<string, string>
                {
                    { "USERNAME", email },
                    { "PASSWORD", password },
                    { "SECRET_HASH", GenerateSecretHash(email)}
                }
            };

            try
            {
                var response = await _provider!.AdminInitiateAuthAsync(request);
                return response.AuthenticationResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> RegisterUserAsync(string email, string password)
        {
            var request = new SignUpRequest
            {
                ClientId = _cognitoSettings!.CognitoClientId,
                Username = email,
                Password = password,
                SecretHash = GenerateSecretHash(email),
                UserAttributes = new List<AttributeType>
                {
                    new AttributeType
                    {
                        Name = "email",
                        Value = email
                    }
                }
            };

            try
            {
                var response = await _provider!.SignUpAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
