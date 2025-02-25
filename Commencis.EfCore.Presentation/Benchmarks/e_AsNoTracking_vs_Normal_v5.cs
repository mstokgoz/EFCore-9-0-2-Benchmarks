using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(10)]
[WarmupCount(10)]
public class e_AsNoTracking_vs_Normal_v5
{
    private readonly BenchmarkDbContext _dbContext;
    private School _school;
    
    public e_AsNoTracking_vs_Normal_v5()
    {
        _dbContext = new BenchmarkDbContext();

        _dbContext.ChangeTracker.LazyLoadingEnabled = false;
    }
    
    [GlobalSetup]
    public void Setup()
    {
        _school = _dbContext.Schools.First();
    }
    
    [Benchmark]
    public async Task Get_With_AsNoTrackingWithIdentityResolution()
    {
        var students = await _dbContext.Students
            .AsNoTrackingWithIdentityResolution()
            .Where(s => s.SchoolId == _school.Id)
            .Take(1000)
            .AsSingleQuery()
            .ToListAsync();
    }

    [Benchmark]
    public async Task Get_With_Tracking()
    {
        var students = await _dbContext.Students
            .Where(s => s.SchoolId == _school.Id)
            .Take(1000)
            .AsSingleQuery()
            .ToListAsync();
    }
}