using _01_ProductCatalog.MVC.Data;
using _01_ProductCatalog.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_ProductCatalog.MVC.Controllers;

public class HomeController(AppDbContext _context) : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var summery = new GlobalSummeryDto
        {
            ShopsCount = _context.Shops.Count(),
            SellersCount = _context.Sellers.Count(),
            ProductsCount = _context.Products.Count(),
            KeywordsCount = _context.Keywords.Count()
        };

        return View(summery);
    }
}
