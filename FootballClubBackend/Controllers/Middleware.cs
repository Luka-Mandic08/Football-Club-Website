using Microsoft.Extensions.Primitives;

namespace FootballClubBackend.Controllers
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Perform custom logic before calling the next middleware
            // e.g., logging, authentication checks

            StringValues token ;
            if(!context.Request.Headers.TryGetValue("Authorization",out token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Middleware works");
                return;
            }

            await _next(context);

            // Perform custom logic after the next middleware has processed the request
            // e.g., response modification
        }
    }
}
