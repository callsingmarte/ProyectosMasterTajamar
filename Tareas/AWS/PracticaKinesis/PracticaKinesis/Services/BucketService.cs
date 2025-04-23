using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

namespace PracticaKinesis.Services
{
    public class BucketService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public BucketService(IConfiguration configuration, IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"]!;
        }

        // Método seguro y asíncrono para guardar un mensaje en Amazon S3
        public async Task SaveMessageToS3(string message)
        {
            try
            {
                var key = $"events-{DateTime.Now:yyyyMMdd-HHmmss}.json";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                var stream = new MemoryStream(messageBytes);

                var putRequest = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = key,
                    InputStream = stream,
                    ContentType = "application/json"
                };

                await _s3Client.PutObjectAsync(putRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[S3 Error] No se pudo guardar el mensaje en S3: {ex.Message}");
                // Aquí puedes usar un logger si prefieres
            }
        }
    }
}
