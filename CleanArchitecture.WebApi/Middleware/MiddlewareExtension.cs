namespace CleanArchitecture.WebApi.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
