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
public class i_Eager_Loading_vs_Explicit_Loading_v3
{
    private readonly BenchmarkDbContext _dbContext;

    public i_Eager_Loading_vs_Explicit_Loading_v3()
    {
        _dbContext = new BenchmarkDbContext();
    }

    [Benchmark]
    public async Task Get_With_Eager_Loading()
    {
        var today = DateTime.UtcNow.Date.AddDays(-2);

        var students = await _dbContext.Students
            .Where(s => s.CreatedAt >= today && s.CreatedAt < today.AddDays(1))
            .Include(s => s.Courses)
            .Take(5)
            .ToListAsync();

        var student = students.FirstOrDefault(s => s.Address.City == "Ankara");
        
        if(student is null)
            return;

        var course = new Course
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            Name = "CE 101",
            LastModificationTime = DateTime.Now,
            TeacherId = Guid.NewGuid()
        };
        
        student.Courses.Add(course);

        await _dbContext.SaveChangesAsync();
    }

    [Benchmark]
    public async Task Get_With_Explicit_Loading()
    {
        var today = DateTime.UtcNow.Date.AddDays(-2);

        var students = await _dbContext.Students
            .Where(s => s.CreatedAt >= today && s.CreatedAt < today.AddDays(1))
            .Take(5)
            .ToListAsync();

        var student = students.FirstOrDefault(s => s.Address.City == "Ankara");
        
        if(student is null)
            return;
        
        await _dbContext.Entry(student)
            .Collection(s => s.Courses)
            .LoadAsync();

        var course = new Course
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            Name = "CE 101",
            LastModificationTime = DateTime.Now,
            TeacherId = Guid.NewGuid()
        };
        
        student.Courses.Add(course);

        await _dbContext.SaveChangesAsync();
    }
}