using Amazon.S3.Model;
using MvcAwsS3.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace MvcAwsS3.Services
{
    public class AWSS3Service
    {
        private AWSS3BucketHelper? _AWSS3BucketHelper;
        private UploadService _UploadService;
        private PathProvider? _PathProvider;

        public AWSS3Service(AWSS3BucketHelper AWSS3BucketHelper, UploadService uploadService, PathProvider PathProvider)
        {
            _AWSS3BucketHelper = AWSS3BucketHelper;
            _UploadService = uploadService;
            _PathProvider = PathProvider;              
        }

        public async Task<bool> UploadFile(string filename, Folders folder)
        {
            try
            {
                string path = _PathProvider!.MapPath(filename, folder);
                using(FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    return await _AWSS3BucketHelper.UploadFile(stream, filename);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetFilesList()
        {
            try
            {
                ListVersionsResponse listVersions = await _AWSS3BucketHelper!.FilesList();
                return listVersions.Versions.Select(c => c.Key).ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Stream> GetFile(string filename)
        {
            try
            {
                Stream fileStream = await _AWSS3BucketHelper.GetFile(filename);
                if (fileStream == null)
                {
                    Exception ex = new Exception("File Not Found");
                    throw ex;
                }
                else
                {
                    return fileStream;
                }
            } catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateFile(string filename, Folders folder)
        {
            try
            {
                string path = _PathProvider!.MapPath(filename, folder);
                using(FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    return await _AWSS3BucketHelper!.UploadFile(stream, filename);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            try
            {
                return await _AWSS3BucketHelper.DeleteFile(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteFile(string fileName, Folders folder)
        {
            try
            {
                await _UploadService.DeleteFileAsync(fileName, folder);
                return await _AWSS3BucketHelper.DeleteFile(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
