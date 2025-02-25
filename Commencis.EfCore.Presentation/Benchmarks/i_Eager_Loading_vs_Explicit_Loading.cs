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
public class i_Eager_Loading_vs_Explicit_Loading
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public i_Eager_Loading_vs_Explicit_Loading()
    {
        _dbContext = new BenchmarkDbContext();
            
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<StudentProfile>();
        });

        _mapper = config.CreateMapper();
    }
    
    [Benchmark]
    public async Task<List<BenchmarkDto>> Get_With_Eager_Loading()
    {
        var students = await _dbContext.Students
            .Take(5)
            .AsNoTracking()
            .Include(s => s.Courses)
            .ToListAsync();
        
        var studentDtos = _mapper.Map<List<BenchmarkDto>>(students);
        
        return studentDtos;
    }
    
    [Benchmark]
    public async Task<List<BenchmarkDto>> Get_With_Explicit_Loading()
    {
        var students = await _dbContext.Students
            .Take(5)
            .AsNoTracking()
            .ToListAsync();

        foreach (var student in students)
        {
            await _dbContext.Entry(student)
                .Collection(s => s.Courses)
                .LoadAsync(); 
        }

        var studentDtos = _mapper.Map<List<BenchmarkDto>>(students);
        
        return studentDtos;
    }
}