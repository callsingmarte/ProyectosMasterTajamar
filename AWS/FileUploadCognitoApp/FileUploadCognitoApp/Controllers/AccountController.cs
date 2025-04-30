using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FileUploadCognitoApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _clientId = "";
        private readonly string _userPoolId = "";
        private readonly string _identityPoolId = "";
        private readonly string _bucketName = "";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/Home/UploadFile" },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirigir a Cognito para el logout, pasando el parámetro client_id
            var clientId = _clientId; // Tu Client ID de Cognito
            var redirectUri = "https://localhost:7260/Home/Index";  // URL de redirección después de logout


            // Realiza el logout en Cognito (esto es lo que redirige a Cognito para cerrar la sesión)
            //return SignOut(new AuthenticationProperties { RedirectUri = "/Home/Index" }, OpenIdConnectDefaults.AuthenticationScheme);
            // La URL de logout de Cognito debe incluir el client_id y la URL de redirección
            var logoutUrl = $"https://us-east-127gvcwz5g.auth.us-east-1.amazoncognito.com/logout?client_id={clientId}&logout_uri={Uri.EscapeDataString(redirectUri)}";

            // Redirigir a Cognito para cerrar sesión
            return Redirect(logoutUrl);
        }
    }
}
