using Doctors.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Infrastructure;

public class DoctorsDbContext(DbContextOptions<DoctorsDbContext> options) : DbContext(options)
{
    public DbSet<DoctorEntity> Doctors { get; set; }
}