using System.Runtime.Serialization;
using _01_ProductCatalog.MVC.Data;
using _01_ProductCatalog.MVC.Models;
using AspNetCore.Scalar;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapOpenApi();
app.UseScalar();

app.MapControllers();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.EnsureCreated();

if(!db.Sellers.Any())
{
    System.Console.WriteLine("Generating Fake Sellers...");
    var sellerFaker = new Faker<Seller>()
        .RuleFor(s => s.Id, f => Guid.NewGuid().ToString())
        .RuleFor(s => s.Name, f => f.Name.FullName())
        .RuleFor(s => s.Bio, f => f.Lorem.Sentences(f.Random.Int(1, 3)))
        .RuleFor(s => s.DateOfBirth, f => f.Date.Past(50, DateTime.UtcNow.AddYears(-18)))
        .RuleFor(s => s.ProfileCreationTime, f => f.Date.Past(5));

    var shopFaker = new Faker<Shop>()
        .RuleFor(s => s.Id, f => Guid.NewGuid().ToString())
        .RuleFor(s => s.ShopName, f => f.Company.CompanyName())
        .RuleFor(s => s.ShopDescription, f => f.Lorem.Sentences(f.Random.Int(1, 4)))
        .RuleFor(s => s.CreationTime, f => f.Date.Past(3));

    var categoryFaker = new Faker<Category>()
        .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
        .RuleFor(c => c.CreationTime, f => f.Date.Past(3));

    var productFaker = new Faker<Product>()
        .RuleFor(p => p.Id, f => Guid.NewGuid().ToString())
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.ProfilePicture, f => f.Internet.Avatar())
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.AvailableStock, f => f.Random.Int(0, 500))
        .RuleFor(p => p.PostedTime, f => f.Date.Past(2));

    var keywordFaker = new Faker<Keyword>()
        .RuleFor(k => k.Name, f => f.Commerce.ProductAdjective());

    // Generate sellers -> shops -> categories -> products and keywords
    var sellers = sellerFaker.Generate(1000);

    // Track category names globally to avoid creating multiple Category
    // instances with the same primary key (Name) which EFCore will reject.
    var globalCategoryNames = new HashSet<string>(db.Categories.Select(c => c.Name).ToList());

    // Create a small pool of keywords
    var keywords = keywordFaker.Generate(2000)
        .GroupBy(k => k.Name)
        .Select(g => g.First())
        .ToList();

    foreach (var seller in sellers)
    {
        var shops = shopFaker.Generate(new Random().Next(1, 4));
        foreach (var shop in shops)
        {
            shop.Owner = seller;
            shop.OwnerId = seller.Id;

            // categories for this shop (unique names)
            var categoryNames = new HashSet<string>();
            var categories = new List<Category>();
            var catCount = new Random().Next(2, 10);
            for (int i = 0; i < catCount; i++)
            {
                var cat = categoryFaker.Generate();
                // ensure uniqueness within shop AND globally (avoid duplicate PK Name)
                if (categoryNames.Add(cat.Name) && globalCategoryNames.Add(cat.Name))
                {
                    cat.Shop = shop;
                    cat.ShopId = shop.Id;
                    categories.Add(cat);
                }
            }
            shop.Categories = categories;

            // products for this shop
            var products = new List<Product>();
            var prodCount = new Random().Next(5, 26);
            for (int i = 0; i < prodCount; i++)
            {
                var prod = productFaker.Generate();
                prod.Shop = shop;
                prod.ShopId = shop.Id;
                // assign a category name (optional)
                var chosenCat = categories.Count > 0 ? categories[new Random().Next(categories.Count)] : null;
                if (chosenCat is not null)
                {
                    prod.Category = chosenCat;
                    prod.CategoryName = chosenCat.Name;
                }

                // assign some keywords
                var kwCount = new Random().Next(0, 5);
                prod.Keywords = new List<Keyword>();
                for (int k = 0; k < kwCount; k++)
                {
                    var kw = keywords[new Random().Next(keywords.Count)];
                    prod.Keywords.Add(kw);
                    // ensure keyword references product
                    if (kw.Products == null) kw.Products = new List<Product>();
                    kw.Products.Add(prod);
                }

                products.Add(prod);
            }

            shop.Products = products;
        }

        seller.OwnedShops = shops;
    }

    // Persist everything
    db.Sellers.AddRange(sellers);
    // also ensure keywords are tracked (they were referenced from products)
    foreach (var kw in keywords)
    {
        if (!db.Set<Keyword>().Local.Any(x => x.Name == kw.Name))
            db.Keywords.Add(kw);
    }

    db.SaveChanges();
}

app.Run();
