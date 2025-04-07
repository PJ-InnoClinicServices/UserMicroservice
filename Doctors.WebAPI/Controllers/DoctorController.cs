using Doctors.Application;
using Doctors.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Doctors.WebAPI.Controllers;
[Route("api/doctors")]
[ApiController]
public class DoctorsController(IDoctorService doctorService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DoctorEntity>), 200)]  
    [ProducesResponseType(404)]  
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await doctorService.GetAllAsync();
        if (doctors == null || !doctors.Any())
        {
            return NotFound("No available doctors");
        }

        return Ok(doctors); 
    }

  
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DoctorEntity), 200)]  
    [ProducesResponseType(404)] 
    public async Task<IActionResult> GetDoctorById(Guid id)
    {
        var doctor = await doctorService.GetByIdAsync(id);
        if (doctor == null)
        {
            return NotFound($"Doctor with ID {id} not found.");
        }

        return Ok(doctor); 
    }

        
    [HttpPost]
    [ProducesResponseType(typeof(DoctorEntity), 201)]  
    [ProducesResponseType(400)] 
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }

        var doctor = await doctorService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);  
    }

        
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(DoctorEntity), 200)]  
    [ProducesResponseType(400)]  
    [ProducesResponseType(404)] 
    public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] UpdateDoctorDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }

        var doctor = await doctorService.UpdateAsync(id, dto);

        return Ok(doctor);  
    }
        
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]  
    [ProducesResponseType(404)] 
    public async Task<IActionResult> DeleteDoctor(Guid id)
    {
        var success = await doctorService.DeleteAsync(id);
        if (!success)
        {
            return NotFound($"Doctor with ID {id} not found.");
        }

        return NoContent();  
    }
}