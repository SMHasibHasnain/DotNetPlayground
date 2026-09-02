using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers;

[ApiController]
[Route("[Controller]")]
public class HomeController : ControllerBase
{   
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Working Home/Index well...");
    }

    public IActionResult About()
    {
        return Ok("Say something about you...");
    }
}
