namespace _01_ProductCatalog.MVC.Models;

public class Keyword
{
    public required string Name { get; set; }

    public List<Product> Products { get; set; } = [];
}
