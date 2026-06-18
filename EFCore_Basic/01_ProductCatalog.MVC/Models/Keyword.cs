using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace _01_ProductCatalog.MVC.Models;

[Table("Product_Keywords")]
public class Keyword
{
    [Key]
    [Column("Keyword_Name")]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Column("Products_In_Keyword")]
    public List<Product> Products { get; set; } = [];
}
