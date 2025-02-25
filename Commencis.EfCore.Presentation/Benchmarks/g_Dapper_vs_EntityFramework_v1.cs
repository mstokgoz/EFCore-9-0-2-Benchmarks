using System.Data;
using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Application.DTOs;
using Commencis.EfCore.Infrastructure;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(3)]
[WarmupCount(0)]
public class g_Dapper_vs_EntityFramework_v1
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly IDbConnection _dbConnection;

    public g_Dapper_vs_EntityFramework_v1()
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
                SchoolId = s.SchoolId
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
    s.ContactInfo_PhoneNumber AS PhoneNumber
FROM Students s;";

        var students = await _dbConnection.QueryAsync<BenchmarkDto, AddressDto, ContactInfoDto, BenchmarkDto>(
            sql,
            (student, address, contactInfo) =>
            {
                student.Address = address;
                student.ContactInfo = contactInfo;
                return student;
            },
            splitOn: "City,Email"
        );
    }
}