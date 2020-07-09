using Microsoft.AspNetCore.Builder;

namespace SwaggerOAS3RestAPI.Middlewares
{
    public static class SwaggerAuthorizeExtensions
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerBasicAuth>();
        }
    }
}