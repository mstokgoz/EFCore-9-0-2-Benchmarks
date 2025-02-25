using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
public class a_GetSequential_vs_NormalGuid
{
    private readonly BenchmarkDbContext _dbContext;
    private readonly BenchmarkSequentialDbContext _seqDbContext;

    private List<Guid> _randomStudentIds_NormalGuid;
    private List<Guid> _randomStudentIds_SequentialGuid;

    public a_GetSequential_vs_NormalGuid()
    {
        _dbContext = new BenchmarkDbContext();
        _seqDbContext = new BenchmarkSequentialDbContext();
    }

    [GlobalSetup]
    public void Setup()
    {
        _randomStudentIds_NormalGuid = _dbContext.Students
            .OrderBy(s => Guid.NewGuid())
            .Take(20000)
            .Select(s => s.Id)
            .ToList();
        
        _randomStudentIds_SequentialGuid = _seqDbContext.Students
            .OrderBy(s => Guid.NewGuid()) 
            .Take(20000)
            .Select(s => s.Id)
            .ToList();
    }

    [Benchmark]
    public List<Student> GetStudents_NormalGuid()
    {
        return _dbContext.Students
            .AsNoTracking()
            .Where(s => _randomStudentIds_NormalGuid.Contains(s.Id))
            .ToList();
    }

    [Benchmark]
    public List<Student> GetStudents_SequentialGuid()
    {
        return _seqDbContext.Students
            .AsNoTracking()
            .Where(s => _randomStudentIds_SequentialGuid.Contains(s.Id))
            .ToList();
    }
}
