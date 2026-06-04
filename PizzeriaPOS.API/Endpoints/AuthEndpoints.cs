using PizzeriaPOS.API.DTOs;
using PizzeriaPOS.API.Services;

namespace PizzeriaPOS.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/api/auth/register", async (RegisterRequest request, AuthService authService) =>
            {
                try
                {
                    var response = await authService.RegisterAsync(request);
                    return Results.Ok(response);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { message = ex.Message });
                }
            })
            .WithName("Register")
            .WithTags("Autenticación")
            .AllowAnonymous();

            app.MapPost("/api/auth/login", async (LoginRequest request, AuthService authService) =>
            {
                try
                {
                    var response = await authService.LoginAsync(request);
                    return Results.Ok(response);
                }
                catch (UnauthorizedAccessException)
                {
                    return Results.Unauthorized();
                }
            })
            .WithName("Login")
            .WithTags("Autenticación")
            .AllowAnonymous();
        }
    }
}
