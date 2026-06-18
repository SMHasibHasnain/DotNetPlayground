namespace _01_ProductCatalog.MVC.Models;

public class Product
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string Name { get; set; } = string.Empty;
    public string? ProfilePicture { get; set; }
    public string? Description { get; set; }
    public int AvailableStock { get; set; }
    public DateTime PostedTime { get; set; } = DateTime.UtcNow;
    
    // Foreign Key
    public required string ShopId { get; set; }
    public string? CategoryName { get; set; }

    // Nav Property
    public required Shop Shop { get; set; }
    public Category? Category { get; set; }
    public List<Keyword>? Keywords { get; set; } 
}
