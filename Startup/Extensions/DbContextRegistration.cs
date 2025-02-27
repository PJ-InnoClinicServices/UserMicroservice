using Doctors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Startup.Extensions;

public static class DbContextRegistration
{
    public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        // doctors database
        services.AddDbContext<DoctorsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DoctorsDefaultConnection")));
    }
}