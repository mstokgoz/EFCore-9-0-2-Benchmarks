using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Domain.ValueObjects;
using Commencis.EfCore.Infrastructure;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(3)]
public class b_InsertQuerySequential_vs_NormalGuid
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly BenchmarkSequentialDbContext _seqDbContext;
    
    private School _school;
    private School _sequentialSchool;

    public b_InsertQuerySequential_vs_NormalGuid()
    {
        _dbContext = new BenchmarkDbContext();
        _seqDbContext = new BenchmarkSequentialDbContext();
    }

    [GlobalSetup]
    public void Setup()
    {
        _school = _dbContext.Schools.First();

       _sequentialSchool = _seqDbContext.Schools.First();
    }

    [Benchmark]
    public void Insert_Student_NormalGuid()
    {
        var student = new Student
        {
            Name = "Test Student",
            SchoolId = _school.Id,
            Address = new Address { City = "Istanbul", Country = "Turkey", Street = "Test Street", PostalCode = "3400", State = "Test State" },
            ContactInfo = new ContactInfo { Email = "sfs@hotmail.com", PhoneNumber = "+905555555555" },
        };
        
        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
    }

    [Benchmark]
    public void Insert_Student_SequentialGuid()
    {
        var student = new Student
        {
            Name = "Test Student",
            SchoolId = _sequentialSchool.Id,
            Address = new Address { City = "Istanbul", Country = "Turkey", Street = "Test Street", PostalCode = "3400", State = "Test State" },
            ContactInfo = new ContactInfo { Email = "sfs@hotmail.com", PhoneNumber = "+905555555555" },
        };
        
        _seqDbContext.Students.Add(student);
        _seqDbContext.SaveChanges();
    }
}