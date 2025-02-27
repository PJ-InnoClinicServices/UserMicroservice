using Doctors.Shared.Entities;
using Nelibur.ObjectMapper;
using Shared.DTOs;

namespace Startup.Extensions
{
    public abstract class MapperRegistration
    {
        public static void AddTinyMapper(IServiceCollection services)
        {
            // doctors mapping
            TinyMapper.Bind<CreateDoctorDto, DoctorEntity>();
            TinyMapper.Bind<UpdateDoctorDto, DoctorEntity>();
        }
    }
}