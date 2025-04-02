using Amazon.Util.Internal;
using MvcAwsS3.Helpers;

namespace MvcAwsS3.Services
{
    public class UploadService
    {
        PathProvider? _pathProvider;

        public UploadService(PathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public async Task<string> UploadFileAsync(IFormFile formfile, Folders folder)
        {
            string filename = formfile.FileName;
            string path = _pathProvider!.MapPath(filename, folder);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await formfile.CopyToAsync(stream);
            }
            return path;
        }

        public async Task<string> UploadFileAsync(IFormFile formfile, string filename, Folders folder)
        {
            string path = _pathProvider!.MapPath(filename, folder);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await formfile.CopyToAsync(stream);
            }
            return path;
        }

        public async Task<string> UploadFileAsync(Stream stream, string filename, Folders folder)
        {
            string path = _pathProvider!.MapPath(filename, folder);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await stream.CopyToAsync(stream);
            }
            return path;
        }

        public async Task<bool> DeleteFileAsync(string fileName, Folders folder)
        {
            string path = _pathProvider!.MapPath(fileName, folder);
            File.Delete(path);

            return true;
        }
    }
}
