using ClienteOAuthEmpleados.Models;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ClienteOAuthEmpleados.Repositories
{
    public class RepositoryEmpleados
    {
        private string url;
        private MediaTypeWithQualityHeaderValue header;

        public RepositoryEmpleados()
        {
            url = "";
            header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<string> GetToken(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);

                LoginModel login = new LoginModel();
                login.UserName = username;
                login.Password = password;

                string json = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                string request = "Auth/Login";
                HttpResponseMessage response = await client.PostAsync(request, content);

                if (response.IsSuccessStatusCode) 
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(data);
                    string token = jobject.GetValue("response").ToString();
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }

        //Sin seguridad
        private async Task<T> CallApi<T>(string request)
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);

                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode) 
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(data, typeof(T))!;
                }
                else
                {
                    return default(T)!;
                }
            }
        }
        //Con seguridad
        private async Task<T> CallApi<T>(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode) 
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(data, typeof(T))!;
                }
                else
                {
                    return default(T)!;
                }
            }
        }
    }
}
