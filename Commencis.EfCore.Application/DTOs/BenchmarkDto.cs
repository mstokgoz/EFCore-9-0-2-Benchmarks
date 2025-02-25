namespace Commencis.EfCore.Application.DTOs;

public class BenchmarkDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public AddressDto Address { get; set; }
    
    public ContactInfoDto ContactInfo { get; set; }
    
    public Guid SchoolId { get; set; }
    
    public List<CourseDto> Courses { get; set; } = [];
    
}