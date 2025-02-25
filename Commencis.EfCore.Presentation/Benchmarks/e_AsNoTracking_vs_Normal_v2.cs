using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(10)]
[WarmupCount(10)]
public class e_AsNoTracking_vs_Normal_v2
{
    private readonly BenchmarkDbContext _dbContext;
    
    public e_AsNoTracking_vs_Normal_v2()
    {
        _dbContext = new BenchmarkDbContext();
    }
    
    [Benchmark]
    public async Task Get_With_AsNoTracking()
    {
        var students = await _dbContext.Students
            .AsNoTracking()
            .Take(1000)
            .ToListAsync();
    }

    [Benchmark]
    public async Task Get_With_Tracking()
    {
        var students = await _dbContext.Students
            .Take(1000)
            .ToListAsync();
    }
}