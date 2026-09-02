namespace Middleware.CustomMiddlewares;

public class SecondCustomMiddleware
{
    public readonly RequestDelegate _next;

    public SecondCustomMiddleware(RequestDelegate next)
    {
        _next = next;        
    }

    public async Task InvokeAsync(HttpContext context)
    {
        System.Console.WriteLine("Starting Second Custom Middleware....");
        await _next(context);
        System.Console.WriteLine("Ending Second Custom Middleware.....");
    }
    
}
