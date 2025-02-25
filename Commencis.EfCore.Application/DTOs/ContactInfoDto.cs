using Commencis.EfCore.Domain.ValueObjects;

namespace Commencis.EfCore.Application.DTOs;

public class ContactInfoDto
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    public static ContactInfoDto From(ContactInfo contactInfo)
    {
        return new ContactInfoDto
        {
            PhoneNumber = contactInfo.PhoneNumber,
            Email = contactInfo.Email
        };
    }
}