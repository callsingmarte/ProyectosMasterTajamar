using Microsoft.AspNetCore.Mvc;
using PracticaS3Bucket.Models;

namespace PracticaS3Bucket.Interfaces
{
    public interface IAwsS3Service
    {
        public Task<bool> CreateBucketAsync(string bucketName);
        public Task<IEnumerable<string>> GetAllBucketAsync();
        public Task<bool> DeleteBucketAsync(string bucketName);
        public Task<string> UploadFileAsync(IFormFile file, string bucketName, string? prefix);
        public Task<IEnumerable<S3ObjectDto>> GetAllFilesAsync(string bucketName, string prefix);
        public Task<byte[]> GetFileByKeyAsync(string bucketName, string key);
        public Task<bool> DeleteFileAsync(string bucketName, string key);
    }
}
