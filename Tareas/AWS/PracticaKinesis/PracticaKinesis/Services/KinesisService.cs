using Amazon.Kinesis.Model;
using Amazon.Kinesis;
using System.Text;
using Amazon;
using PracticaKinesis.Models;

namespace PracticaKinesis.Services
{
    public class KinesisService
    {
        private readonly AmazonKinesisClient? _kinesisClient;
        private readonly string? _streamName;
        private static Dictionary<string, string> _lastIterators = new();

        public KinesisService(IConfiguration configuration)
        {
            var region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]);
            _kinesisClient = new AmazonKinesisClient(
                configuration["AWS:AccessKey"],
                configuration["AWS:SecretKey"],
                region);

            _streamName = configuration["AWS:StreamName"]!;
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

        public async Task<List<SensorEvent>> ReadMessagesAsync(int count = 10)
        {
            var messages = new List<SensorEvent>();

            var describeRequest = new DescribeStreamRequest
            {
                StreamName = _streamName,
            };

            var streamDesc = await _kinesisClient.DescribeStreamAsync(describeRequest);
            var shards = streamDesc.StreamDescription.Shards;

            foreach (var shard in shards)
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
                    SensorEvent parsedData = SensorEventParser.ParseJson(data);
                    messages.Add(parsedData);
                }
            }

            return messages;
        }
    }
}
