using Microsoft.AspNetCore.Mvc;
using MvcAwsS3.Helpers;
using MvcAwsS3.Services;

namespace MvcAwsS3.Controllers
{
    public class AwsFilesController : Controller
    {
        private UploadService? _uploadService;
        private AWSS3Service? _AWSS3Service;

        public AwsFilesController(UploadService uploadService, AWSS3Service aWSS3Service)
        {
            _uploadService = uploadService;
            _AWSS3Service = aWSS3Service;
        }

        public ActionResult Index() 
        {
            //Mostrar todas las acciones para ficheros del bucket
            return View();          
        }

        public async Task<IActionResult> FilesListAWS()
        {
            List<string> files = await _AWSS3Service!.GetFilesList();
            return View(files);
        }

        public IActionResult UploadFileAWS()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAWS(IFormFile file)
        {
            var tipo = file.ContentType.ToString();
            bool respuesta = false;
            int posicion = tipo.IndexOf("/");
            var tipofichero = tipo.Substring(0, posicion);
            if(tipofichero == "image")
            {
                await _uploadService!.UploadFileAsync(file, Helpers.Folders.Images);
                respuesta = await _AWSS3Service!.UploadFile(file.FileName, Folders.Images);
            }
            else if(tipofichero == "text")
            {
                await _uploadService!.UploadFileAsync(file, Folders.Documents);
                respuesta = await _AWSS3Service!.UpdateFile(file.FileName, Folders.Documents);
            }
            else
            {
                await _uploadService!.UploadFileAsync(file, Folders.Temporal);
                respuesta = await _AWSS3Service!.UpdateFile(file.FileName, Folders.Temporal);
            }

            ViewData["MENSAJE"] = "Fichero subido a AWS: " + respuesta;
            return View();
        }

        public async Task<IActionResult> FileAWS(string filename)
        {
            var posicion = filename.IndexOf(".");
            string extension = filename.Substring(posicion + 1);
            string[] extensiones_imagenes = { "jpg", "jpeg", "gif", "png", "tiff", "tif", "RAW", "bmp", "psd", "pdf", "eps", "pic" };
            bool esImagen = extensiones_imagenes.Contains(extension);
            string formato = "";
            if (esImagen) 
            {
                formato = "image/png";
            }
            else

            {
                switch (extension)

                {

                    case "txt":

                        formato = "text/plain";

                        break;

                    case "docx":

                        formato = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                        break;

                    case "pptx":

                        formato = "application/vnd.openxmlformats-officedocument.presentationml.presentation";

                        break;

                    default:

                        break;

                }
            }

            if(filename == null)
            {
                return View();
            }
            else
            {
                var file = await _AWSS3Service.GetFile(filename);
                return File(file, formato);
            }
        }

        public IActionResult EditFileAWS(string filename)
        {
            ViewData["FILENAME"] = filename;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditFileAWS(IFormFile file, string filename)
        {
            if (file == null)
            {
                return View();
            }
            else
            {
                var tipo = file.ContentType.ToString();
                bool respuesta = false;
                int posicion = tipo.IndexOf("/");
                var tipofichero = tipo.Substring(0, posicion);
                Folders carpeta = Folders.Images;
                if(tipofichero == "image")
                {
                    carpeta = Folders.Images;
                }else if(tipofichero == "text")
                {
                    carpeta = Folders.Documents;
                }
                else
                {
                    carpeta = Folders.Temporal;
                }

                //Sustituyo el fichero en el servidor
                await _uploadService!.UploadFileAsync(file, carpeta);

                //Borro el fichero en AWS
                await _AWSS3Service.DeleteFile(filename, carpeta);

                //Borramos el fichero en nuestro servidor
                //Subo el archivo nuevo a AWS

                respuesta = await _uploadService.DeleteFileAsync(filename, carpeta);
                await _AWSS3Service.UpdateFile(file.FileName, carpeta);

                ViewData["FILENAME"] = file.FileName;
                ViewData["MENSAJE"] = "Fichero Actualizado en AWS " + respuesta;

                return View();
            }
        }
        public async Task<IActionResult> DeleteFileAWS(string filename)
        {
            var posicion = filename.LastIndexOf(".");
            string extension = filename.Substring(posicion + 1);
            string[] extensiones_imagenes = { "jpg", "jpeg", "gif", "png", "tiff", "tif", "RAW", "bmp", "psd", "pdf", "eps", "pic" };
            bool esImagen = extensiones_imagenes.Contains(extension);
            Folders carpeta = Folders.Images;
            if (esImagen)
            {
                carpeta = Folders.Images;
            }
            else
            {
                switch (extension)
                {
                    case "txt":
                        carpeta = Folders.Documents;
                        break;
                    default:
                        carpeta = Folders.Documents;
                        break;
                }
            }

            await _AWSS3Service.DeleteFile(filename, carpeta);
            return RedirectToAction("FilesListAWS");
        }
    }
}
