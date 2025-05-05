using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Publicaciones.Interfaces;
using System.Security.Claims;
using System.Text.Json;

namespace Publicaciones.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICognitoService _cognitoService;
        private readonly string _clientId = "";

        public AccountController(ICognitoService cognitoService, IConfiguration configuration)
        {
            _cognitoService = cognitoService;
            _clientId = configuration["CognitoClientId"];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string confirmPassword)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (password != confirmPassword) 
            {
                ModelState.AddModelError("", "Las contraseñas no coinciden.");
                return View();
            }

            var result = await _cognitoService.RegisterUserAsync(email, password);

            if (result)
            {
                TempData["Message"] = "Registro completado con exito. Por favor confirma tu email";
                return RedirectToAction("ConfirmEmail");
            }

            ModelState.AddModelError("", "Registro fallido. Por favor prueba otra vez.");
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _cognitoService.ConfirmEmailAsync(email, code);

            if (result) 
            {
                TempData["Message"] = "Email verificado con exito. Ahora puedes iniciar sesion";

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Verificacion de email fallida. Comprueba el codigo e intentalo de nuevo");

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/Publicaciones" },
                OpenIdConnectDefaults.AuthenticationScheme);
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            // Inicio de sesion sin OpenId
            if (!ModelState.IsValid)
            {
                return View();
            }

            var authResult = await _cognitoService.LoginUserAsync(email, password);

            if (authResult != null) 
            {
                string? userId = GetSubFromIdToken(authResult.IdToken);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier, userId ?? "")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("Cookies", claimsPrincipal);

                TempData["Message"] = "¡Inicio de sesion con exito!";

                return RedirectToAction("Index", "Publicaciones");
            }
            else
            {
                TempData["LoginFailed"] = true;
                ModelState.AddModelError("", "Inicio de sesion fallido. ¡Credenciales invalidas!");
 
                return View();
            }
        }

        private string? GetSubFromIdToken(string idToken)
        {
            var parts = idToken.Split('.');
            if (parts.Length != 3)
                return null;

            var payload = parts[1];

            // Relleno para Base64
            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');

            var bytes = Convert.FromBase64String(payload);
            var json = System.Text.Encoding.UTF8.GetString(bytes);

            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("sub", out var sub))
            {
                return sub.GetString();
            }

            return null;
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var redirectUri = "https://localhost:7260/Home/";
            var logoutUrl = $"https://us-east-1qvveonnii.auth.us-east-1.amazoncognito.com/logout?client_id={_clientId}&logout_uri={Uri.EscapeDataString(redirectUri)}";

            return RedirectToAction(logoutUrl);

            /*
             * Cierre de sesion sin OpenId
             * 
                TempData["Message"] = "Has cerrado sesion";
                await HttpContext.SignOutAsync("Cookies");
            */

        }

    }
}
