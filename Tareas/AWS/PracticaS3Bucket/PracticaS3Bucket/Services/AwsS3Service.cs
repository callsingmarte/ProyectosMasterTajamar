using Microsoft.AspNetCore.Mvc;
using PracticaS3Bucket.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using PracticaS3Bucket.Models;

namespace PracticaS3Bucket.Services
{
    public class AwsS3Service : IAwsS3Service
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AwsS3Service> _logger;

        public AwsS3Service(HttpClient httpClient, ILogger<AwsS3Service> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> CreateBucketAsync(string bucketName)
        {
            try
            {
                var url = $"buckets/create?bucketName={Uri.EscapeDataString(bucketName)}";
                var response = await _httpClient.PostAsync(url, null);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error en la petición HTTP: {response.StatusCode} - {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la peticion HTTP: {ex}");
                return false;
            }
        }

        public async Task<bool> DeleteBucketAsync(string bucketName)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"buckets/delete?bucketName={bucketName}");

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error en la petición HTTP: {response.StatusCode} - {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la peticion HTTP: {ex}");
                return false;
            }
        }

        public async Task<bool> DeleteFileAsync(string bucketName, string key)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"files/delete?bucketName={bucketName}&key={key}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la peticion HTTP: {ex}");
                return false;
            }
        }

        public async Task<IEnumerable<string>> GetAllBucketAsync()
        {
            try
            {
                var respuesta = await _httpClient.GetAsync("buckets/get-all");

                if (!respuesta.IsSuccessStatusCode)
                {
                    _logger.LogError($"Error en la peticion HTTP: {respuesta.StatusCode}");
                    return [];
                }

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var lista = JsonSerializer.Deserialize<IEnumerable<string>>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return lista ?? [];
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la peticion HTTP: {ex}");
                return [];
            }
        }

        public async Task<IEnumerable<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix = "")
        {
            try
            {
                var url = $"files/get-all?bucketName={bucketName}";
                if (!string.IsNullOrEmpty(prefix))
                {
                    url += $"&prefix={prefix}";
                }
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Error en la peticion HTTP: {response.StatusCode} - {errorMessage }");
                    return [];
                }

                var contenido = await response.Content.ReadAsStringAsync();
                var lista = JsonSerializer.Deserialize<IEnumerable<S3ObjectDto>>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return lista ?? [];
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la peticion HTTP: {ex}");
                return [];
            }
        }

        public async Task<byte[]> GetFileByKeyAsync(string bucketName, string key)
        {
            var response = await _httpClient.GetAsync($"files/get-by-key?bucketName={bucketName}&key={key}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al obtener el archivo: {response.ReasonPhrase}");
            }

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> UploadFileAsync(IFormFile file, string bucketName, string? prefix="")
        {
            using var formData = new MultipartFormDataContent();
            using var streamContent = new StreamContent(file.OpenReadStream());

            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            formData.Add(streamContent, "file", file.FileName);
            formData.Add(new StringContent(bucketName, Encoding.UTF8, "text/plain"), "bucketName");
            formData.Add(new StringContent(prefix ?? "", Encoding.UTF8, "text/plain"), "prefix");

            var response = await _httpClient.PostAsync("files/upload", formData);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Error en la peticion HTTP: {response.StatusCode} - { errorMessage }");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
