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
            url = "https://apiempleadoscoreoauth20250227013009-ctcbfkbrg9hrh2av.northeurope-01.azurewebsites.net/";
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

                string request = "api/Auth/Login";
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

        //Todos los metodos
        //Sin Seguridad
        public async Task<Empleado> BuscarEmpleado(int empno)
        {
            Empleado emp = await CallApi<Empleado>("api/empleados/" + empno);
            return emp;
        }

        //Con seguridad
        public async Task<Empleado> PerfilEmpleado(string token)
        {
            Empleado emp = await CallApi<Empleado>("api/empleados/perfilempleado", token);
            return emp;
        }

        public async Task<List<Empleado>> GetSubordinados(string token)
        {
            List<Empleado> empleados = await CallApi<List<Empleado>>("api/empleados/subordinados", token);
            return empleados;
        }

    }
}
