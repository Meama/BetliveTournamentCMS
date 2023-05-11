namespace Api.Middleware;

public static class MiddlewareExtentions
{
    public static void AddAuthentication(this IApplicationBuilder app)
    {
        app.UseMiddleware<AuthenticationMiddleware>();
    }
    public static void AddErrorHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}