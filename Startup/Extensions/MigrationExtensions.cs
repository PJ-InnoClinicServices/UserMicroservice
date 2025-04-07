using Doctors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Startup.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using DoctorsDbContext context = scope.ServiceProvider.GetRequiredService<DoctorsDbContext>();
        context.Database.Migrate();
    }
}