﻿using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S3DemoApi.Models;
using S3DemoApi.ViewModels;

namespace S3DemoApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IAmazonS3? _s3Client;

        public FilesController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFileAsync([FromForm]UploadFileRequest fileRequest)
        {
            IFormFile file = fileRequest.file;
            string bucketName = fileRequest.bucketName;
            string prefix = fileRequest.prefix;

            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return BadRequest($"bucket {bucketName} does not exists.");

            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')} / {file.FileName}",
                InputStream = file.OpenReadStream()
            };

            request.Metadata.Add("Content-Type", file.ContentType);
            await _s3Client!.PutObjectAsync(request);

            return Ok($"File {prefix}/{file.FileName} upload to S3 successfully");
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllFilesAsync(string bucketName, string? prefix = "")
        {
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return BadRequest($"bucket {bucketName} does not exists.");

            var request = new ListObjectsV2Request()
            {
                BucketName = bucketName,
                Prefix = prefix
            };

            var result = await _s3Client!.ListObjectsV2Async(request);

            var s3Objects = result.S3Objects.Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMinutes(1)
                };
                return new S3ObjectDto()
                {
                    Name = s.Key.ToString(),
                    PresignedUrl = _s3Client.GetPreSignedURL(urlRequest)
                };
            });

            return Ok(s3Objects);
        }

        [HttpGet("get-by-key")]
        public async Task<IActionResult> GetFileByKeyAsync(string bucketName, string key)
        {
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return BadRequest($"bucket {bucketName} does not exists.");

            var s3Object = await _s3Client!.GetObjectAsync(bucketName, key);

            return File(s3Object.ResponseStream, s3Object.Headers.ContentType);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFileAsync(string bucketName, string key)
        {
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return BadRequest($"bucket {bucketName} does not exists.");

            await _s3Client!.DeleteObjectAsync(bucketName, key);
            return NoContent();
        }
    }
}
