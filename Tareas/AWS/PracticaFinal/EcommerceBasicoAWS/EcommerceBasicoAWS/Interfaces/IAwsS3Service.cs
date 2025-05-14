namespace EcommerceBasicoAWS.Interfaces
{
    public interface IAwsS3Service
    {
        public Task<string> UploadFileAsync(IFormFile file, string bucketName, string? prefix);
        public Task<byte[]> GetFileByKeyAsync(string bucketName, string key);
        public Task<bool> DeleteFileAsync(string bucketName, string key);

    }
}
