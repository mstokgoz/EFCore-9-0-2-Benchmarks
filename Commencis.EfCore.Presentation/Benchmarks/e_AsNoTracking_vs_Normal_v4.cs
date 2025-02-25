using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
public class e_AsNoTracking_vs_Normal_v4
{
    private readonly BenchmarkDbContext _dbContext;
    
    public e_AsNoTracking_vs_Normal_v4()
    {
        _dbContext = new BenchmarkDbContext();
    }
    
    [Benchmark]
    public async Task Get_With_AsNoTracking()
    {
        var students = await _dbContext.Students
            .AsNoTracking()
            .Take(10)
            .ToListAsync();
    }

    [Benchmark]
    public async Task Get_With_Tracking()
    {
        var students = await _dbContext.Students
            .Take(10)
            .ToListAsync();
    }
}