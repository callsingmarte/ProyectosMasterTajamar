using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MvcKmsDemo.Services
{
    public class KmsService
    {
        private readonly IAmazonKeyManagementService? _kmsClient;
        private readonly string _keyId;

        public KmsService(IAmazonKeyManagementService ksmClient, IConfiguration config)
        {
            _kmsClient = ksmClient;
            _keyId = config["AWS:KmsKeyId"] ?? throw new Exception("Clave KMS no encontrada");
        }

        public async Task<string> EncryptAsync(string plaintext)
        {
            var request = new EncryptRequest
            {
                KeyId = _keyId,
                Plaintext = new MemoryStream(Encoding.UTF8.GetBytes(plaintext))
            };

            var response = await _kmsClient!.EncryptAsync(request);

            return Convert.ToBase64String(response.CiphertextBlob.ToArray());
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
