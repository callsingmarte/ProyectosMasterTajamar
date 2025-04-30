using System.Diagnostics;
using Amazon.S3;
using Amazon.S3.Model;
using FileUploadCognitoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadCognitoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAmazonS3 _s3Client;

        public HomeController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [Authorize]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Nombre único para el archivo, por ejemplo usando GUID
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var uploadRequest = new PutObjectRequest
                {
                    BucketName = "mi-bucket002",
                    Key = fileName,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType
                };

                // Subir el archivo a S3
                var response = await _s3Client.PutObjectAsync(uploadRequest);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.Message = "Archivo subido correctamente!";
                }
                else
                {
                    ViewBag.Message = "Error al subir el archivo.";
                }
            }
            else
            {
                ViewBag.Message = "No se seleccionó ningún archivo.";
            }

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
