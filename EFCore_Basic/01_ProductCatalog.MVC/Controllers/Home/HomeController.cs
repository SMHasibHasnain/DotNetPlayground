using Microsoft.AspNetCore.Mvc;

namespace _01_ProductCatalog.MVC.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}
