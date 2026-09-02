namespace Middleware.CustomExtensions;
using Middleware.CustomMiddleware;

public static class FirstCustomMiddlewareExtension
{
    public static IApplicationBuilder UseFirstCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FirstCustomMiddleware>();
    }
}
