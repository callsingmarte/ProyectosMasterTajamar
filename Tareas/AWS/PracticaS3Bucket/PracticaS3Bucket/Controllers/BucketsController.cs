﻿using Microsoft.AspNetCore.Mvc;
using PracticaS3Bucket.Services;

namespace PracticaS3Bucket.Controllers
{
    public class BucketsController : Controller
    {
        private readonly AwsS3Service _awsS3Service;

        public BucketsController(AwsS3Service awsS3Service)
        {
            _awsS3Service = awsS3Service;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _awsS3Service.GetAllBucketAsync();

            return View(response);
        }

        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string bucketName)
        {
            var response = await _awsS3Service.CreateBucketAsync(bucketName);

            string viewContent = $"Se ha creado el bucket {bucketName} con exito";

            if (!response)
            {
                viewContent = $"Se ha producido un error al crear el bucket {bucketName}";
            }

            return View("OperationStatus", viewContent);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string bucketName) 
        {
            var response = await _awsS3Service.DeleteBucketAsync(bucketName);

            string viewContent = $"El bucket {bucketName} se ha eliminado con exito!";

            if (!response)
            {
                viewContent = $"Se ha producido un error al eliminar el bucket {bucketName}";
            }

            return View("OperationStatus", viewContent);
        }
    }
}
