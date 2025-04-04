namespace S3DemoApi.ViewModels
{
    public class UploadFileRequest
    {
        public IFormFile? file { get; set; } 
        public string? bucketName { get; set; }
        public string? prefix { get; set; }
    }
}
