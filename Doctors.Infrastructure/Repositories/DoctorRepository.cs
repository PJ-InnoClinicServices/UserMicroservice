using Doctors.Domain.IRepositories;
using Doctors.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using Shared.DTOs;

namespace Doctors.Infrastructure.Repositories;

public class DoctorRepository(DoctorsDbContext context) : IDoctorRepository
{
    public async Task<IEnumerable<DoctorEntity>> GetAllAsync()
    {
        return await context.Doctors.ToListAsync();
    }

    public async Task<DoctorEntity> GetByIdAsync(Guid id)
    {
        return await context.Doctors.FindAsync(id);
    }

    public async Task<DoctorEntity> CreateAsync(CreateDoctorDto dto)
    {
        var doctor = TinyMapper.Map<DoctorEntity>(dto);

        doctor.Id = Guid.NewGuid();  
        context.Doctors.Add(doctor);
        await context.SaveChangesAsync();
        return doctor;
    }

    public async Task<DoctorEntity> UpdateAsync(Guid id, UpdateDoctorDto dto)
    {
        var doctor = await context.Doctors.FindAsync(id);
        if (doctor == null) return null;
            
        TinyMapper.Map(dto, doctor); 

        context.Doctors.Update(doctor);
        await context.SaveChangesAsync();
        return doctor;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var doctor = await context.Doctors.FindAsync(id);
        if (doctor == null) return false;

        context.Doctors.Remove(doctor);
        await context.SaveChangesAsync();
        return true;
    }
}