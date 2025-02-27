using Common.Application;
using Doctors.Shared.Entities;
using Shared.DTOs;

namespace Doctors.Application;

public interface IDoctorService : IService<DoctorEntity,CreateDoctorDto, UpdateDoctorDto>
{
}