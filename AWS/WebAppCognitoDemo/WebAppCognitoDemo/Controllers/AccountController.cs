using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppCognitoDemo.Models;
using WebAppCognitoDemo.Services;

namespace WebAppCognitoDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICognitoService _cognitoService;
        private readonly AwsCognitoSettings _awsCognitoSettings;
        private readonly IAmazonCognitoIdentityProvider _provider;

        public AccountController(
            ICognitoService cognitoService, 
            AwsCognitoSettings cognitoSettings,
            IAmazonCognitoIdentityProvider provider)
        {
            _cognitoService = cognitoService;
            _awsCognitoSettings = cognitoSettings;
            _provider = provider;
        }

        //Registrar 
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

            if(password != confirmPassword)
            {
                ModelState.AddModelError("", "Las contraseñas no coinciden.");
                return View();
            }

            var result = await _cognitoService.RegisterUserAsync(email, password);

            if (result)
            {
                TempData["Message"] = "Registration successfull. Please confirm your email";
                return RedirectToAction("ConfirmEmail");
            }

            ModelState.AddModelError("", "Registration failed. Please try again.");
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
                TempData["Message"] = "Email confirmed successfully. You can now log in";

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Email confirmation failed. Check the code and try again");
            return View();
        }

        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var authResult = await _cognitoService.LoginUserAsync(email, password);

            if(authResult != null)
            {
                //Las claims son como pildoras de identidad
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Email, email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                //Emitir la cookie
                await HttpContext.SignInAsync("Cookies", claimsPrincipal);

                TempData["Message"] = "Login Successfully!";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginFailed"] = true;
                ModelState.AddModelError("", "Login failed. Invalid credentials!");

                return View();
            }

        }

        //Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            TempData["Message"] = "You have been logout";
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Login");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
