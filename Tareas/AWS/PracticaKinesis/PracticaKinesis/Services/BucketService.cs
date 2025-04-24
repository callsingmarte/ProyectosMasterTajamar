using Amazon.S3;
using Amazon.S3.Model;
using PracticaKinesis.Models;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<bool> SaveMessageToS3(SensorEvent data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                var key = $"events-{DateTime.Now:yyyyMMdd-HHmmssff}.json";
                var messageBytes = Encoding.UTF8.GetBytes(json);
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
                return false;
            }

            return true;
        }

        public async Task<bool> SaveMessageListToS3(List<SensorEvent> data)
        {
            foreach (var sensorEvent in data) {
                try
                {
                    bool response = await SaveMessageToS3(sensorEvent);
                    if (!response) {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
