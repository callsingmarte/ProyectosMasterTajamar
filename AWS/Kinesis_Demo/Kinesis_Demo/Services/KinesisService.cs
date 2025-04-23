using Amazon;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

namespace Kinesis_Demo.Services
{
    public class KinesisService
    {
        private readonly AmazonKinesisClient? _kinesisClient;
        private readonly string? _streamName;
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;
        private static Dictionary<string, string> _lastIterators = new();

        public KinesisService(IConfiguration configuration, IAmazonS3 s3Client)
        {
            var region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);
            _kinesisClient = new AmazonKinesisClient(
                configuration["AWS:AccessKey"],
                configuration["AWS:SecretKey"], 
                region);

            _streamName = configuration["AWS:StreamName"]!;
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"]!;
        }

        //Metodo para enviar mensajes a kinesis
        public async Task SendMessageAsync(string message)
        {
            var request = new PutRecordRequest
            {
                StreamName = _streamName,
                PartitionKey = Guid.NewGuid().ToString(),
                Data = new MemoryStream(Encoding.UTF8.GetBytes(message))
            };

            await _kinesisClient!.PutRecordAsync(request);
        }

        //Metodo para poder leer mensajes desde kinesis (hasta 10)
        public async Task<List<MessageWithIndex>> ReadMessagesAsync(int count = 10)
        {
            var messages = new List<MessageWithIndex>();
            int index = 1;

            var describeRequest = new DescribeStreamRequest
            {
                StreamName = _streamName,
            };

            var streamDesc = await _kinesisClient.DescribeStreamAsync(describeRequest);
            var shards = streamDesc.StreamDescription.Shards;
            foreach(var shard in shards)
            {
                string shardId = shard.ShardId;
                string shardIterator;

                if (_lastIterators.ContainsKey(shardId))
                {
                    shardIterator = _lastIterators[shardId];
                }
                else
                {
                    var iteratorRequest = new GetShardIteratorRequest
                    {
                        StreamName = _streamName,
                        ShardId = shard.ShardId,
                        ShardIteratorType = ShardIteratorType.TRIM_HORIZON
                    };

                    var iteratorResponse = await _kinesisClient.GetShardIteratorAsync(iteratorRequest);

                    shardIterator = iteratorResponse.ShardIterator;
                }

                var recordResponse = await _kinesisClient.GetRecordsAsync(new GetRecordsRequest
                {
                    ShardIterator = shardIterator,
                    Limit = count
                });

                _lastIterators[shardId] = recordResponse.NextShardIterator!; // Guardamos el nuevo iterador

                foreach (var record in recordResponse.Records)
                {
                    string data = Encoding.UTF8.GetString(record.Data.ToArray());
                    messages.Add(new MessageWithIndex
                    {
                        Index = index++,
                        Message = data
                    });
                }
            }

            return messages;
        }

        //Metodo para guardar un mensaje en Amazon S3
        public async Task SaveMessageToS3(string message, int index)
        {
            var key = $"messages/{index}_{Guid.NewGuid()}.txt";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var stream = new MemoryStream(messageBytes);

            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = key,
                InputStream = stream,
                ContentType = "text/plain"
            };

            //Subimos al S3
            await _s3Client.PutObjectAsync(putRequest);
        }
    }

    public class MessageWithIndex
    {
        public int Index { get; set; }
        public string? Message { get; set; }
    }

}
