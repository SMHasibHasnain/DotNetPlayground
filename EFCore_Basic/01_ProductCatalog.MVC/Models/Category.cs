namespace _01_ProductCatalog.MVC.Models;

public class Category
{
    public required string Name { get; set; }

    public DateTime PostedTime { get; set; } = DateTime.UtcNow;   

    public required Shop ShopId { get; set; }

    public required Shop Shop { get; set; }

    public List<Product>? Products { get; set; }
}
