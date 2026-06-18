using Microsoft.EntityFrameworkCore;
using _01_ProductCatalog.MVC.Models;

namespace _01_ProductCatalog.MVC.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext (options)
{
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Category> Categories { get; set; }
}
