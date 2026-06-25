using _01_ProductCatalog.MVC.Data;
using _01_ProductCatalog.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_ProductCatalog.MVC;

[Route("[controller]")]
public class ShopController(AppDbContext _context) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> Shops()
    {
        var shops = new ShopListDto();
        shops.AllShops = await _context.Shops
            .Where(x => x.OwnerId != null)
            .Include(x => x.Owner)
            .ToListAsync();
        return View(shops);
    }
}
