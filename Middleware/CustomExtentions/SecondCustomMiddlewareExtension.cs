using Middleware.CustomMiddlewares;

namespace Middleware.CustomExtentions;

public static class SecondCustomMiddlewareExtension
{
    public static IApplicationBuilder UseSecondCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SecondCustomMiddleware>();
    }
}
