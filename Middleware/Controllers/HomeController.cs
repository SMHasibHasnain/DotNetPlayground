using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers;

[ApiController]
[Route("[Controller]")]
public class HomeController : ControllerBase
{   
    
    [HttpGet]
    public ActionResult<Person[]> Index()
    {
        Person[] arr1 = new Person[]
        { 
            new() { Name = "Hasib", Message = "Hello World" },
            new() { Name = "Hamim", Message = "Wanna Eat!" },

        };

        return arr1;
    }

    public IActionResult About()
    {
        return Ok("Say something about you...");
    }
}

public class Person
{
    public string Name { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}