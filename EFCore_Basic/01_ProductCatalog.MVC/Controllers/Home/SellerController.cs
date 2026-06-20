using _01_ProductCatalog.MVC.Data;
using _01_ProductCatalog.MVC.Models;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_ProductCatalog.MVC.Controllers;

[Route("Seller")]
public class SellerController (AppDbContext _context) : Controller
{
    public IActionResult Sellers()
    {
        var sellerList = new SellerListDto
        {
            SellerList = _context.Sellers
        };
        return View(sellerList);
    }

    [Route("{id}")]
    public async Task<IActionResult> SingleSellerAsync([FromRoute] string id)
    {
        var seller = await _context.Sellers
            .Include(s => s.OwnedShops)
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seller == null)
        {
            return NotFound();
        }    

        var model = new SellerDto
        {
            Id = seller.Id,
            Name = seller.Name,
            Bio = seller.Bio,
            DateOfBirth = seller.DateOfBirth,
            ProfileCreationTime = seller.ProfileCreationTime,
            OwnedShops = seller.OwnedShops
        };

        return View(model);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByNameAsync([FromQuery] string Name)
    {

        if(string.IsNullOrWhiteSpace(Name))
        {
            return RedirectToAction("Sellers");
        }

        var seller = await _context.Sellers
            .Where(x => x.Name.Contains(Name))
            .ToListAsync();

        if(!seller.Any())
        {
            return NotFound();
        }

        var model = new SellerListDto
        {
            SellerList = seller
        };

        ViewBag.Name = Name;

        return View(model);
    }
}
