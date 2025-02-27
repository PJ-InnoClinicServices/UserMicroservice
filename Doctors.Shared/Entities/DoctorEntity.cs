using Common.Domain;

namespace Doctors.Shared.Entities;

public class DoctorEntity : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }  
    public string PhoneNumber { get; set; } 
    public string Specialty { get; set; }
    public string LicenseNumber { get; set; }
    public DateTime DateOfBirth { get; set;}
    public DateTime DateJoined { get; set; }
}



  