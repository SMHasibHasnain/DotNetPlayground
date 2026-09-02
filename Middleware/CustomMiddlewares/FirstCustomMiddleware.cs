using System.Net;

namespace Middleware.CustomMiddleware;
class FirstCustomMiddleware
{
    private readonly RequestDelegate _next;
    public FirstCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        System.Console.WriteLine("Starts FirstCustomMiddleware...");
        var startTimer = DateTime.Now;
        await _next(context);
        var time = DateTime.Now - startTimer;
        System.Console.WriteLine($"Time: {time}");
        System.Console.WriteLine("Ends FirstCustomMiddleware...");
    }    
}