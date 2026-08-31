var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

// Middleware C
app.Use(async (context, next) =>
{
    System.Console.WriteLine("C");
    await next(); 
    System.Console.WriteLine("C");
});



app.MapGet("/", () => "Hello World!");

app.Run();
