using Doctors.Infrastructure;

namespace Startup.Extensions;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddDoctorsServices();
        // services.AddPatientsServices();
    }
}