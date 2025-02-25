using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(3)]
[WarmupCount(0)]
public class e_AsNoTracking_vs_AsNoTrackingWithIdentityResolution
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly BenchmarkSequentialDbContext _seqDbContext;

    private School _school;
    private School _sequentialSchool;

    public e_AsNoTracking_vs_AsNoTrackingWithIdentityResolution()
    {
        _dbContext = new BenchmarkDbContext();
    }
    
    [GlobalSetup]
    public void Setup()
    {
        _school = _dbContext.Schools.First();
    }

    [Benchmark]
    public async Task Get_With_AsNoTracking()
    {
        var students = await _dbContext.Students
            .Take(100)
            .Include(c => c.Courses)
            .AsNoTracking()
            .ToListAsync();
       
    }

    [Benchmark]
    public async Task Get_With_AsNoTrackingWithIdentityResolution()
    {
        var students = await _dbContext.Students
            .Take(100)
            .Include(c => c.Courses)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}