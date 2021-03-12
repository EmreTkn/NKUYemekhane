using Microsoft.AspNetCore.Builder;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;

namespace API.Middleware
{
    public static class JwtTokenMiddleware
    {

        public static IApplicationBuilder UseJwtTokenMiddleware(
            this IApplicationBuilder app,
            string schema = "Bearer")
        {
            return app.Use((async (ctx, next) =>
            {
                IIdentity identity = ctx.User.Identity;
                if ((identity != null ? (!identity.IsAuthenticated ? 1 : 0) : 1) != 0)
                {
                    AuthenticateResult authenticateResult = await ctx.AuthenticateAsync(schema);
                    if (authenticateResult.Succeeded && authenticateResult.Principal != null)
                        ctx.User = authenticateResult.Principal;
                }
                await next();
            }));
        }
    }
}
