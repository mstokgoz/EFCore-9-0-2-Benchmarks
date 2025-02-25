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
public class f_Projection_Loading_vs_Eager_Loading
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly IMapper _mapper;
    private IQueryable<BenchmarkDto> _query;
    private IIncludableQueryable<Student, List<Course>> _includableQueryable;
   
    
    public f_Projection_Loading_vs_Eager_Loading()
    {
        _dbContext = new BenchmarkDbContext();
            
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<StudentProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [GlobalSetup]
    public void Setup()
    {
        _includableQueryable = _dbContext.Students
            .AsNoTracking()
            .Include(c => c.Courses);
        
        _query = _dbContext.Students
            .AsNoTracking()
            .Select(s => new BenchmarkDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = new AddressDto
                {
                    City = s.Address.City,
                    Country = s.Address.Country,
                    Street = s.Address.Street
                },
                ContactInfo = new ContactInfoDto
                {
                    Email = s.ContactInfo.Email,
                    PhoneNumber = s.ContactInfo.PhoneNumber
                },
                SchoolId = s.SchoolId,
                Courses = s.Courses.Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            });
        
        Console.WriteLine($"Eager Sql Query: {_includableQueryable.ToQueryString()}");
        
        Console.WriteLine($"Projection Sql Query: {_query.ToQueryString()}");
        
        Console.WriteLine();
    }
    
    
    [Benchmark]
    public async Task<List<BenchmarkDto>> Get_With_Eager_Loading()
    {
        var students = await _includableQueryable.ToListAsync();
        
        var studentDtos = _mapper.Map<List<BenchmarkDto>>(students);
        
        return studentDtos;
    }

    [Benchmark]
    public async Task<List<BenchmarkDto>> Get_With_Projection_Loading()
    {
      return await _query.ToListAsync();
    }
}