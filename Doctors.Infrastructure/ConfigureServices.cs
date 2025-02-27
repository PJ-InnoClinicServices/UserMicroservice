using Doctors.Application;
using Doctors.Domain.IRepositories;
using Doctors.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Doctors.Infrastructure;

public static class ConfigureServices
{
    public static void AddDoctorsServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IDoctorService, DoctorService>();
                
    }
}