using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ProductCatalog.MVC.Models;

[Table("Products")]
public class Product
{
    [Column("Product_Id")]
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    
    [Column("Product_Name")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [Column("Product_Profile_Picture")]
    [MaxLength(2000)]
    public string? ProfilePicture { get; set; }
    
    [Column("Product_Description")]
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Column("Product_Available_Stock")]
    public int AvailableStock { get; set; }

    [Column("Product_Posted_Time")]
    public DateTime PostedTime { get; set; } = DateTime.UtcNow;
    
    // Foreign Key
    [Column("Product_Shop_Id")]
    public required string ShopId { get; set; }
    
    [Column("Product_Category_Name")]
    public string? CategoryName { get; set; }

    // Nav Property
    public required Shop Shop { get; set; }
    public Category? Category { get; set; }
    public List<Keyword>? Keywords { get; set; } 
}
