using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(3)]
[WarmupCount(0)]
public class d_Multiple_Join_vs_Split_Queries
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly BenchmarkSequentialDbContext _seqDbContext;

    private School _school;
    private School _sequentialSchool;

    public d_Multiple_Join_vs_Split_Queries()
    {
        _dbContext = new BenchmarkDbContext();
    }
    

    [Benchmark]
    public async Task Get_With_Multiple_Joins()
    {
        var schools = await _dbContext.Schools
            .Take(10)
            .AsNoTracking()
            .Include(s => s.Students)
            .ThenInclude(s => s.Courses)
            .Include(s => s.Teachers)
            .ToListAsync();
    }

    [Benchmark]
    public async Task Get_With_Split_Query()
    {
        var schools = await _dbContext.Schools
            .Take(10)
            .AsNoTracking()
            .Include(s => s.Students)
            .ThenInclude(s => s.Courses)
            .Include(s => s.Teachers)
            .AsSplitQuery()
            .ToListAsync();
    }
}