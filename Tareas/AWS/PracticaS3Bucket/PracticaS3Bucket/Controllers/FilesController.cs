using Microsoft.AspNetCore.Mvc;
using PracticaS3Bucket.Models;
using PracticaS3Bucket.Services;

namespace PracticaS3Bucket.Controllers
{
    public class FilesController : Controller
    {
        private readonly AwsS3Service _awsS3Service;

        public FilesController(AwsS3Service awsS3Service)
        {
            _awsS3Service = awsS3Service;
        }

        public async Task<IActionResult> Index(string bucketName)
        {
            IEnumerable<S3ObjectDto> response = await _awsS3Service.GetAllFilesAsync(bucketName);

            return View(response);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, string bucketName)
        {
            var response = await _awsS3Service.UploadFileAsync(file, bucketName);

            return View();
        }

        public async Task<IActionResult> Download(string bucketName, string key)
        {
            var response = await _awsS3Service.GetFileByKeyAsync(bucketName, key);

            return View(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string bucketName, string key)
        {
            var response = await _awsS3Service.DeleteFileAsync(bucketName, key);

            return View("", response);
        }
    }
}
