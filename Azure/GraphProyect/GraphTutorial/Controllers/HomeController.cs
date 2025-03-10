using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GraphTutorial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using System.Threading.Tasks;

namespace GraphTutorial.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ITokenAcquisition _tokenAcquisition;

    public HomeController(ITokenAcquisition tokenAcquisition, ILogger<HomeController> logger)
    {
        _tokenAcquisition = tokenAcquisition;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            string token = await _tokenAcquisition.GetAccessTokenForUserAsync(GraphConstants.Scopes);
            return View().WithInfo("Token acquired", token);
        }
        catch (MicrosoftIdentityWebChallengeUserException ex) 
        {
            return Challenge();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [AllowAnonymous]
    public IActionResult ErrorWithMessage(string message, string debug)
    {
        return View("Index").WithError(message, debug);
    }
}
