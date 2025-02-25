using System.Data;
using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Application.DTOs;
using Commencis.EfCore.Infrastructure;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(10)]
[WarmupCount(0)]
public class g_Dapper_vs_EntityFramework_v4
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly IDbConnection _dbConnection;

    public g_Dapper_vs_EntityFramework_v4()
    {
        _dbContext = new BenchmarkDbContext();
        _dbConnection =
            new SqlConnection(
                "Server=localhost,1433;Database=BenchmarkDb;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=True;TrustServerCertificate=True;");
    }

    [Benchmark]
    public async Task Get_With_EfCore()
    {
        await _dbContext.Students
            .AsNoTracking()
            .Take(100)
            .Select(s => new BenchmarkDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = new AddressDto
                {
                    City = s.Address.City,
                    Country = s.Address.Country,
                    Street = s.Address.Street
                },
                ContactInfo = new ContactInfoDto
                {
                    Email = s.ContactInfo.Email,
                    PhoneNumber = s.ContactInfo.PhoneNumber
                },
                SchoolId = s.SchoolId,
                Courses = s.Courses.Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            })
            .ToListAsync();
    }

    [Benchmark]
    public async Task Get_With_Dapper()
    {
        string sql = @"
        SELECT TOP 100 
            s.Id, 
            s.Name, 
            s.SchoolId, 
            s.Address_City AS City, 
            s.Address_Country AS Country, 
            s.Address_Street AS Street, 
            s.ContactInfo_Email AS Email, 
            s.ContactInfo_PhoneNumber AS PhoneNumber,
            c.Id AS CourseId,
            c.Name AS CourseName
        FROM Students s
        LEFT JOIN CourseStudent cs ON cs.StudentsId = s.Id
        LEFT JOIN Courses c ON c.Id = cs.CoursesId";

        var studentDictionary = new Dictionary<Guid, BenchmarkDto>();

        var students =
            await _dbConnection.QueryAsync<BenchmarkDto, AddressDto, ContactInfoDto, CourseDto, BenchmarkDto>(
                sql,
                (student, address, contactInfo, course) =>
                {
                    if (!studentDictionary.TryGetValue(student.Id, out var studentEntry))
                    {
                        studentEntry = student;
                        studentEntry.Address = address;
                        studentEntry.ContactInfo = contactInfo;
                        studentEntry.Courses = new List<CourseDto>();
                        studentDictionary.Add(student.Id, studentEntry);
                    }

                    studentEntry.Courses.Add(course);
                    
                    return studentEntry;
                },
                splitOn: "City,Email,CourseId"
            );
    }
}