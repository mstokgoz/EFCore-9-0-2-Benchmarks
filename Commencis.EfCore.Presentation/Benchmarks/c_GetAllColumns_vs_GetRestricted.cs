using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(3)]
public class c_GetAllColumns_vs_GetRestricted
{
    private readonly BenchmarkDbContext _dbContext;
    

    private School _school;
    private School _sequentialSchool;

    public c_GetAllColumns_vs_GetRestricted()
    {
        _dbContext = new BenchmarkDbContext();
    }
    

    [Benchmark]
    public async Task Get_All_Columns()
    {
        var school = await _dbContext.Schools.FirstAsync();
        
        var students = await _dbContext.Students.Where(s => s.SchoolId == school.Id).ToListAsync();
    }

    [Benchmark]
    public async Task Get_Restricted()
    {
        var schoolId = await _dbContext.Schools.Select(s => s.Id).FirstAsync();
        
        var students = await _dbContext.Students
            .Where(s => s.SchoolId == schoolId)
            .Select(s => new { s.Id, s.Name })
            .ToListAsync();
    }
}