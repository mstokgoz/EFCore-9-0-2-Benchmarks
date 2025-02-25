using Commencis.EfCore.Domain.Aggregates;

namespace Commencis.EfCore.Application.DTOs;

public class SchoolDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public AddressDto Address { get; set; }
    
    public ContactInfoDto ContactInfo { get; set; }

    public static SchoolDto From(School school)
    {
        return new SchoolDto 
        {
            Id = school.Id,
            Name = school.Name,
            Address = AddressDto.From(school.Address),
            ContactInfo = ContactInfoDto.From(school.ContactInfo)
        };
    }
}