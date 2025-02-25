using Commencis.EfCore.Application.DTOs;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Domain.ValueObjects;

namespace Commencis.EfCore.Application.Profile;

public class StudentProfile : AutoMapper.Profile
{
    public StudentProfile()
    {
        CreateMap<Student, BenchmarkDto>();
        CreateMap<Address, AddressDto>();
        CreateMap<ContactInfo, ContactInfoDto>();
        CreateMap<Course, CourseDto>();
    }
}