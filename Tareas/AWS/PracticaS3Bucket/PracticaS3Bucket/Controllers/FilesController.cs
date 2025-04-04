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
            ViewBag.bucketName = bucketName;

            return View(response);
        }

        public IActionResult Upload(string bucketName)
        {
            ViewBag.bucketName = bucketName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, string bucketName)
        {
            if (file == null || file.Length == 0)
            {
                return View("OperationStatus", "Advertencia el archivo no puede estar vacío.");
            }

            var response = await _awsS3Service.UploadFileAsync(file, bucketName);

            if (!response.Contains("successfully"))
            {
                response = $"Se ha producido un error al subir el archivo al bucket {bucketName}";
                return View("OperationStatus", response);
            }

            return RedirectToAction("Index", new { bucketName });
        }

        [HttpPost]
        public async Task<IActionResult> Download(string bucketName, string key)
        {
            var response = await _awsS3Service.GetFileByKeyAsync(bucketName, key);

            if (response == null)
            {
                return View("OperationStatus", "Se ha producido un error al descargar el archivo");
            }

            var contentType = "application/octet-stream";

            return File(response, contentType, key);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string bucketName, string key)
        {
            var response = await _awsS3Service.DeleteFileAsync(bucketName, key);

            if (!response)
            {
                return View("OperationStatus", "Se ha producido un error al eliminar el archivo");
            }

            return RedirectToAction("Index", new { bucketName});
        }
    }
}
