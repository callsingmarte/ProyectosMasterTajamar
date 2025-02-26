
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace ClienteConsolaAPI
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class Program
    {
        const string userName = "REY";
        const string password = "7839";
        const string apiBaseUri = "https://localhost:7263/api/";

        private static async Task<string> GetAPIToken(string userName, string password, string apiBaseUri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Login login = new Login();
                login.Username = userName;
                login.Password = password;
                string json = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                string peticion = "Auth/Login";
                HttpResponseMessage response = await client.PostAsync(peticion, content);
                string contenido = await response.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(contenido);
                return jObject.GetValue("response")!.ToString();
            }
        }

        static async Task<string> GetRequest(string token, string requestPath)
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(apiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await client.GetAsync(requestPath);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        static void Main(string[] args) 
        {
            //Conseguir el token
            var token = GetAPIToken(userName, password, apiBaseUri).Result;
            Console.WriteLine("Token: {0}", token);

            //Hacemos la llamada
            var response = GetRequest(token, "Empleados").Result;
            Console.WriteLine("Response: {0}", response);

            Console.ReadKey();
        }
    }
}