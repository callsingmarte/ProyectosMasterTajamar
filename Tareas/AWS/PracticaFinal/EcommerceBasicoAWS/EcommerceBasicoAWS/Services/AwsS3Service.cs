using EcommerceBasicoAWS.Interfaces;
using System.Text;
using System.Net.Http.Headers;

namespace EcommerceBasicoAWS.Services
{
    public class AwsS3Service : IAwsS3Service
    {
        private readonly ILogger<AwsS3Service> _logger;
        public AwsS3Service(ILogger<AwsS3Service> logger)
        {
            _logger = logger;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string bucketName, string? prefix = "")
        {
            return "";
        }
        public async Task<byte[]> GetFileByKeyAsync(string bucketName, string key)
        {
            return [];
        }
        public async Task<bool> DeleteFileAsync(string bucketName, string key)
        {
            return false;
        }
    }
}
