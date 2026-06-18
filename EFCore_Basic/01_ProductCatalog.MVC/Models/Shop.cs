using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ProductCatalog.MVC.Models;

[Table("Shops")]
public class Shop
{
    [Key]
    [Column("Shop_Id")]
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    
    [MaxLength(50)]
    [Column("Shop_Name")]
    public string ShopName { get; set; } = string.Empty;

    [MaxLength(200)]
    [Column("Shop_Description")]
    public string ShopDescription { get; set; } = string.Empty;

    [Column("Creation_Time")]
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    //Foreign Key
    [Column("Shop_Owner_Id")]
    public string? OwnerId { get; set; }

    // Navigation Property 
    public Seller? Owner { get; set; }
    public List<Product> Products { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
}
