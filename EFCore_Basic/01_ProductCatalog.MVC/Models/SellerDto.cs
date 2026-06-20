using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ProductCatalog.MVC.Models;


public class SellerDto
{    public string? Id { get; set; } 
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Bio { get; set; }
    public DateTime ProfileCreationTime { get; set; }
    public List<Shop> OwnedShops { get; set; } = [];
}
