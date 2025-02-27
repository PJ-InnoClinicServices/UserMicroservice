using Doctors.WebAPI.Controllers;

namespace Startup.Extensions;

public static class AssemblyRegistration
{
    public static void AddAssemblies(this IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(DoctorController).Assembly);
        // .AddApplicationPart(typeof(PatientController).Assembly);
    }
}