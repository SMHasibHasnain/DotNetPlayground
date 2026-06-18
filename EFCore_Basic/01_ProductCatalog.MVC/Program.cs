using _01_ProductCatalog.MVC;
using AspNetCore.Scalar;
using Microsoft.EntityFrameworkCore;

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

app.Run();
