using Doctors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Startup.Extensions;

public static class DbContextRegistration
{
    public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var dbPassword = Environment.GetEnvironmentVariable("NEON_DB_PASSWORD");
        var connectionString = configuration.GetConnectionString("DoctorsDefaultConnection")
            .Replace("${NEON_DB_PASSWORD}", dbPassword);
        
        // doctors database
        services.AddDbContext<DoctorsDbContext>(options =>
            options.UseNpgsql(connectionString,
                npgsqlOptions => { npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_Doctors"); }));
    }
}