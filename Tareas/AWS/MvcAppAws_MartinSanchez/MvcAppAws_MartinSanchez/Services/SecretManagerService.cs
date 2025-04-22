using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text;
using System.Text.Json;

namespace MvcAppAws_MartinSanchez.Services
{
    public class SecretManagerService
    {
        private readonly IConfiguration _configuration;
        private readonly AmazonSecretsManagerClient _secretsManagerClient;
        private readonly IAmazonKeyManagementService? _kmsClient;

        public SecretManagerService(IConfiguration configuration, IAmazonKeyManagementService kmsClient)
        {
            _configuration = configuration;
            _secretsManagerClient = new AmazonSecretsManagerClient(
                _configuration["AWS:AccessKeyId"],
                _configuration["AWS:SecretAccessKey"],
                Amazon.RegionEndpoint.GetBySystemName(_configuration["Aws:Region"])
                );
            _kmsClient = kmsClient;
        }

        public async Task<string> GetSecretValueAsync(string secretName)
        {
            try
            {
                var request = new GetSecretValueRequest
                {
                    SecretId = secretName
                };
                var response = await _secretsManagerClient.GetSecretValueAsync(request);

                string secretString = response.SecretString ?? Convert.ToBase64String(response.SecretBinary.ToArray());
                //Secret manager ya descrifra la clave de kms y no hace falta descrifrarla
                //string secretStringDecrypted = await DecryptAsync(secretString);
                var secretDict = JsonSerializer.Deserialize<Dictionary<string, string>>(secretString);

                if (secretDict != null && secretDict.TryGetValue("DefaultConnection", out var connectionString))
                {
                    return connectionString;
                }
                throw new Exception("No se encontro 'DefaultConnection' en los secretos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DecryptAsync(string encryptedText)
        {
            var request = new DecryptRequest
            {
                CiphertextBlob = new MemoryStream(
                    Convert.FromBase64String(encryptedText)
                )
            };
            
            var response = await _kmsClient!.DecryptAsync(request);

            return Encoding.UTF8.GetString(response.Plaintext.ToArray());
        }

    }
}
