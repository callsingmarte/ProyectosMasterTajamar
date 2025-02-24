using CosmosDBCategoriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CosmosDBCategoriesAPI.Interfaces
{
    public interface IBlobService
    {
        Task<string?> GetPictureUrl(string blobName);
        Task<bool> UploadFile(Stream file, string fileName);
        Task Delete(string blobName);
    }
}
