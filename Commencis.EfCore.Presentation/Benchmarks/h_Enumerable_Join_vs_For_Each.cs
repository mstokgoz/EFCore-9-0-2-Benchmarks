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
public class h_Enumerable_Join_vs_For_Each
{
    private readonly BenchmarkDbContext _dbContext;
    private List<Student> students;
    private List<School> schools;

    public h_Enumerable_Join_vs_For_Each()
    {
        _dbContext = new BenchmarkDbContext();
    }

    [GlobalSetup]
    public void Setup()
    {
        students = _dbContext.Students
            .AsNoTracking()
            .ToList();
        
        schools = _dbContext.Schools
            .AsNoTracking()
            .ToList();
    }


    [Benchmark]
    public List<StudentSchoolDto> Get_With_For_Each()
    {
        List<StudentSchoolDto> studentSchoolDtos = [];

        foreach (var student in students)
        {
            var school = schools.FirstOrDefault(s => s.Id == student.SchoolId) ?? new School();

            var studentSchoolDto = StudentSchoolDto.From(student, school);

            studentSchoolDtos.Add(studentSchoolDto);
        }

        return studentSchoolDtos;
    }

    [Benchmark]
    public  List<StudentSchoolDto> Get_With_Enumerable_Join()
    {
        var studentSchoolDtos = from student in students
            join school in schools on student.SchoolId equals school.Id
            select StudentSchoolDto.From(student, school);

        return studentSchoolDtos.ToList();
    }
}