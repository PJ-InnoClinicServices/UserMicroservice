using Doctors.Domain.IRepositories;
using MassTransit;
using Shared.DTOs.Doctor;

namespace Doctors.Infrastructure;

public class DoctorExistsConsumer(IDoctorRepository doctorRepository) : IConsumer<DoctorExistsRequest>
{
    public async Task Consume(ConsumeContext<DoctorExistsRequest> context)
    {
        var doctor = await doctorRepository.GetByIdAsync(context.Message.DoctorId);
        if (doctor != null)
        {
                await context.RespondAsync(new DoctorExistsResponse { Exists = true });
        }
        await context.RespondAsync(new DoctorExistsResponse { Exists = false });
    }
}