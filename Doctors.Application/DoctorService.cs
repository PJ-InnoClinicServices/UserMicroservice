using Doctors.Domain.IRepositories;
using Doctors.Shared.Entities;
using Shared.DTOs;

namespace Doctors.Application;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    public async Task<IEnumerable<DoctorEntity>> GetAllAsync()
    {
        return await doctorRepository.GetAllAsync();
    }
        
    public async Task<DoctorEntity> GetByIdAsync(Guid id)
    {
        return await doctorRepository.GetByIdAsync(id);
    }
        
    public async Task<DoctorEntity> CreateAsync(CreateDoctorDto dto)
    {
        return await doctorRepository.CreateAsync(dto);
    }
        
    public async Task<DoctorEntity> UpdateAsync(Guid id, UpdateDoctorDto dto)
    {
        return await doctorRepository.UpdateAsync(id, dto);
    }
        
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await doctorRepository.DeleteAsync(id);
    }
}