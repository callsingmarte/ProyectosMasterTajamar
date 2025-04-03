using Amazon.S3;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace S3DemoApi.Controllers
{
    [Route("api/buckets")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        private readonly IAmazonS3? _s3Client;
        public BucketsController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBucketAsync(string bucketName)
        {
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);

            if (bucketExists) return BadRequest($"bucket {bucketName} already exists.");
            
            await _s3Client.PutBucketAsync(bucketName);

            return Ok($"bucket {bucketName} created");
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBucketAsync()
        {
            var data = await _s3Client.ListBucketsAsync();
            var buckets = data.Buckets.Select(b => { return b.BucketName; });

            return Ok(buckets);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBucketAsync(string bucketName)
        {
            await _s3Client.DeleteBucketAsync(bucketName);
            return NoContent();
        }

    }
}
