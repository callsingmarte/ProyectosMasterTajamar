using Amazon;
using Amazon.SimpleNotificationService;
using Microsoft.Extensions.Options;
using PracticaAwsSnS.Models;

namespace PracticaAwsSnS.Services
{
    public class SnsService
    {
        private readonly AmazonSimpleNotificationServiceClient _snsClient;
        private readonly string? _snsTopicArn;

        public SnsService(IOptions<AwsSettings> awsSettings)
        {
            _snsClient = new AmazonSimpleNotificationServiceClient(
                            awsSettings.Value.Accesskey,
                            awsSettings.Value.SecretKey,
                            RegionEndpoint.GetBySystemName(awsSettings.Value.Region)
                        );
            _snsTopicArn = awsSettings.Value.SnsTopicArn;
        }

        public async Task<bool> SendNotification(string message)
        {
            try
            {
                _snsClient.PublishAsync(_snsTopicArn, message).Wait();
            }
            catch (Exception ex) {
                return false;
            }

            return true;
        }
    }
}
