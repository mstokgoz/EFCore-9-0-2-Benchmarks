using Commencis.EfCore.Domain.Aggregates;

namespace Commencis.EfCore.Application.DTOs;

public class StudentSchoolDto
{
    public StudentDto Student { get; set; }
    
    public SchoolDto School { get; set; }

    public static StudentSchoolDto From(Student student, School school)
    {
        return new StudentSchoolDto
        {
            Student = StudentDto.From(student),
            School = SchoolDto.From(school)
        };
    }
}