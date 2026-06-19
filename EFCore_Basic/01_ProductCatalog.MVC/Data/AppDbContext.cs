using Microsoft.EntityFrameworkCore;
using _01_ProductCatalog.MVC.Models;
using Microsoft.Extensions.Options;

namespace _01_ProductCatalog.MVC.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext (options)
{
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Category> Categories { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Seller>().HasData(
    //         new Seller
    //         {   
    //             Id = "seller-1",
    //             Name = "Hasib Hasnain",
    //             DateOfBirth = new DateTime(2002, 7, 4),
    //             Bio = "It's a simple bio!",
    //             ProfileCreationTime = new DateTime(2026, 1, 1)
    //         },
    //         new Seller
    //         {
    //             Id = "seller-2",
    //             Name = "Rahim Iqbal",
    //             DateOfBirth = new DateTime(2000, 3, 13),
    //             Bio = "Honest and Elegent Seller!",
    //             ProfileCreationTime = new DateTime(2026, 1, 1)
    //         },
    //         new Seller
    //         {
    //             Id = "seller-3",
    //             Name = "Tamim Iqbal",
    //             DateOfBirth = new DateTime(1997, 9, 22),
    //             Bio = "Selling My Used Bat Balls!",
    //             ProfileCreationTime = new DateTime(2026, 1, 1)
    //         }
    //     );
    // }

}
