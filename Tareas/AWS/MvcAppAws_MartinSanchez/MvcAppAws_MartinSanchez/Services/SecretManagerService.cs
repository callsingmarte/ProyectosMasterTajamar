using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json;

namespace MvcAppAws_MartinSanchez.Services
{
    public class SecretManagerService
    {
        private readonly IConfiguration _configuration;
        private readonly AmazonSecretsManagerClient _secretsManagerClient;

        public SecretManagerService(IConfiguration configuration)
        {
            _configuration = configuration;
            _secretsManagerClient = new AmazonSecretsManagerClient(
                _configuration["AWS:AccessKeyId"],
                _configuration["AWS:SecretAccessKey"],
                Amazon.RegionEndpoint.GetBySystemName(_configuration["Aws:Region"])
                );
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
    }
}
