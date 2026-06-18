using Microsoft.EntityFrameworkCore;

namespace _01_ProductCatalog.MVC;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext (options)
{
    
}
