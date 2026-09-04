var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var routeGroup = app.MapGroup("/api")
    .WithTags("1st Category");

routeGroup.MapGet("/", () => "Hello World!");

routeGroup.MapGet("id/{id:int:min(0)}", (int id) =>
{
   return Results.Ok($"Tyying to access id = {id}"); 
});

routeGroup.MapGet("name/{name:alpha:length(3,10)}", (string name) =>
{
   return Results.Ok($"Your input {name} is valid!"); 
});

routeGroup.MapGet("tags", (string[] tags) =>
{
    return Results.Ok(
        new {Total = tags.Length, 
        tags}
    );
});

app.Run();
