using AutoMapper;
using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Application.DTOs;
using Commencis.EfCore.Application.Profile;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(3)]
[WarmupCount(0)]
public class f_Get_With_AutoMapper_vs_Restricted_Dto
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public f_Get_With_AutoMapper_vs_Restricted_Dto()
    {
        _dbContext = new BenchmarkDbContext();
        
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<StudentProfile>();
        });

        _mapper = config.CreateMapper();
    }
    
    [Benchmark]
    public async Task<List<BenchmarkDto>> Get_With_AutoMapper()
    {
        var students = await _dbContext.Students
            .AsNoTracking()
            .Take(10000)
            .ToListAsync();

        var studentDtos = _mapper.Map<List<BenchmarkDto>>(students);

        return studentDtos;
    }

    [Benchmark]
    public async Task<List<BenchmarkDto>> Get_With_RestrictedDto()
    {
        return await _dbContext.Students
            .AsNoTracking()
            .Take(10000)
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
                SchoolId = s.SchoolId
            })
            .ToListAsync();
    }
}