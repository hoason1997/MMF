using Microsoft.AspNetCore.Builder;

namespace MFF.WEB.Data
{
    public static class IdentityMiddlewareExtensions
    {
        public static IApplicationBuilder SeedIdentityData(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InitData>();
        }
    }
}