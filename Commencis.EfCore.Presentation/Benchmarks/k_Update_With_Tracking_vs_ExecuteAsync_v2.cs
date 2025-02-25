using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;


[MemoryDiagnoser]
[IterationCount(10)]
[WarmupCount(10)]
public class k_Update_With_Tracking_vs_ExecuteAsync_v2
{
    private readonly BenchmarkDbContext _dbContext;

    public k_Update_With_Tracking_vs_ExecuteAsync_v2()
    {
        _dbContext = new BenchmarkDbContext();
    }

    [Benchmark]
    public async Task Update_With_Related()
    {
        var students = await _dbContext.Students
            .ToListAsync();

        var teachers = await _dbContext.Teachers
            .ToListAsync();

        foreach (var student in students)
        {
            student.CreatedAt = DateTime.Now;
        }

        foreach (var teacher in teachers)
        {
            teacher.CreatedAt = DateTime.Now;
        }

        await _dbContext.SaveChangesAsync();
    }
    

    [Benchmark]
    public async Task Update_With_Execution()
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.Students
                .ExecuteUpdateAsync(setters => setters.SetProperty(s => s.CreatedAt, DateTime.Now));
        
            await _dbContext.Teachers
                .ExecuteUpdateAsync(setters => setters.SetProperty(t => t.CreatedAt, DateTime.Now));
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
        }
        
    }
}