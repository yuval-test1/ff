using Fdf.APIs;

namespace Fdf;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
    }
}
