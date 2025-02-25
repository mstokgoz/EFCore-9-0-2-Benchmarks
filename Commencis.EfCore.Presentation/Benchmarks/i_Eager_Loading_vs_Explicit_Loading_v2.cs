using AutoMapper;
using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Application.DTOs;
using Commencis.EfCore.Application.Profile;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(5)]
[WarmupCount(5)]
public class i_Eager_Loading_vs_Explicit_Loading_v2
{
    private readonly BenchmarkDbContext _dbContext;
    
    public i_Eager_Loading_vs_Explicit_Loading_v2()
    {
        _dbContext = new BenchmarkDbContext();
    }

    [Benchmark]
    public async Task Get_With_Eager_Loading()
    {
        var today = DateTime.UtcNow.Date;
        
        var students = await _dbContext.Students
            .AsNoTracking()
            .Where(s => s.CreatedAt >= today && s.CreatedAt < today.AddDays(1))
            .Include(s => s.Courses)
            .ToListAsync();

        foreach (var course in students.Where(s => s.Address.City == "Ankara" ).SelectMany(s => s.Courses))
        {
            Console.WriteLine(course.Name);
        }
    }

    [Benchmark]
    public async Task Get_With_Explicit_Loading()
    {
        var _dbContext = new BenchmarkDbContext();

        var today = DateTime.UtcNow.Date.AddDays(-1);
        
        var students = await _dbContext.Students
            .Where(s => s.CreatedAt >= today && s.CreatedAt < today.AddDays(1))
            .ToListAsync();

        foreach (var student in students.Where(student => student.Address.City == "Ankara"))
        {
            await _dbContext.Entry(student)
                .Collection(s => s.Courses)
                .LoadAsync();
        }
        
        foreach (var course in students.Where(s => s.Address.City == "Ankara" ).SelectMany(s => s.Courses))
        {
            Console.WriteLine(course.Name);
        }
    }
}