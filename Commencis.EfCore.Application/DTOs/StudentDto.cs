using Commencis.EfCore.Domain.Aggregates;

namespace Commencis.EfCore.Application.DTOs;

public class StudentDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public AddressDto Address { get; set; }
    
    public ContactInfoDto ContactInfo { get; set; }
    
    public static StudentDto From(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Address = AddressDto.From(student.Address),
            ContactInfo = ContactInfoDto.From(student.ContactInfo)
        };
    }
}