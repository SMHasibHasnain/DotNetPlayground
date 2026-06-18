using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ProductCatalog.MVC.Models;

[Table("Shop_Categories")]
public class Category
{
    [Key]
    [Column("Category_Name")]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Column("Category_Creation_Time")]
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;   

    [Column("Category_Shop_Id")]
    public required string ShopId { get; set; }

    public required Shop Shop { get; set; }

    public List<Product>? Products { get; set; }
}
