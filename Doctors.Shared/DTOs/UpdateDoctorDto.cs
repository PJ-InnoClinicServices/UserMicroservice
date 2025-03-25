namespace Shared.DTOs;

public record UpdateDoctorDto
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }  
    public string Specialty { get; set; } 
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }  
}