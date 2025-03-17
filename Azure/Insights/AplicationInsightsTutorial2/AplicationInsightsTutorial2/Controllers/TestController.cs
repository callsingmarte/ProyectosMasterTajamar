using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
  
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Se ha realizado una solicitud GET al controlador Test.");
        return Ok(new { Message = "¡Application Insights funcionando!" });
    }
}