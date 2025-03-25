using Common.Domain;
using Doctors.Shared.Entities;
using Shared.DTOs;

namespace Doctors.Domain.IRepositories;

public interface IDoctorRepository : IRepository<DoctorEntity,CreateDoctorDto, UpdateDoctorDto>
{
}