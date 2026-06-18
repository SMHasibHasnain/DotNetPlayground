namespace _01_ProductCatalog.MVC.Models;

public class Seller
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Bio { get; set; } = string.Empty;
    public DateTime ProfileCreationTime { get; set; } = DateTime.UtcNow;

    // Navigation Property 
    public List<Shop> OwnedShops { get; set; } = [];
}
