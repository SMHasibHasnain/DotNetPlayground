using Middleware.CustomExtensions;
using Middleware.CustomExtentions;
using Middleware.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();


app.UseCors("AllowFrontend");

// Middleware A
app.Use(async (context, next) => {
    System.Console.WriteLine("A");
    await next(); 
    System.Console.WriteLine("A");
});

// Middleware B
app.Use(async (context, next) =>
{
    System.Console.WriteLine("B");
    await next(); 
    System.Console.WriteLine("B");
});

// First Conventional Custom Middleware
app.UseFirstCustomMiddleware();

// Second Conventional Custom Middleware
app.UseSecondCustomMiddleware();

// Middleware C
app.Use(async (context, next) =>
{
    System.Console.WriteLine("C");
    await next(); 
    System.Console.WriteLine("C");
});

// app.MapGet("/", () => "Hello World!");

app.UseRouting();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}"
// );

app.MapControllers();

app.Run();
