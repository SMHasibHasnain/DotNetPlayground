using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_ProductCatalog.MVC.Models;

[Table("Shop_Sellers")]
public class Seller
{
    [Column("Shop_Id")]
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    
    [Column("Seller_Name")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [Column("Date_Of_Birth")]
    public DateTime DateOfBirth { get; set; }
    
    [Column("Seller_Bio")]
    [MaxLength(150)]
    public string Bio { get; set; } = string.Empty;
    
    [Column("Profile_Creation_Time")]
    public DateTime ProfileCreationTime { get; set; } = DateTime.UtcNow;

    // Navigation Property 
    public List<Shop> OwnedShops { get; set; } = [];
}   
