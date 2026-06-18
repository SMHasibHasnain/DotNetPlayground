namespace _01_ProductCatalog.MVC.Models;

public class Shop
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string ShopName { get; set; } = string.Empty;
    public string ShopDescription { get; set; } = string.Empty;
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    //Foreign Key
    public string? OwnerId { get; set; }

    // Navigation Property 
    public Seller? Owner { get; set; }
    public List<Product> Products { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
}
