using BenchmarkDotNet.Attributes;
using Commencis.EfCore.Domain.Aggregates;
using Commencis.EfCore.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Commencis.EfCore.Presentation.Benchmarks;

[MemoryDiagnoser]
[IterationCount(2)]
[WarmupCount(0)]
public class j_Delete_Related_vs_ExecuteAsync
{
    private readonly BenchmarkDbContext _dbContext;

    public j_Delete_Related_vs_ExecuteAsync()
    {
        _dbContext = new BenchmarkDbContext();
    }

    [Benchmark]
    public async Task Delete_With_Related()
    {
        var school = await _dbContext.Schools
            .Include(s => s.Students)
            .ThenInclude(s => s.Courses)
            .Include(s => s.Teachers)
            .ThenInclude(t => t.Courses)
            .FirstAsync();

        // _dbContext.Schools.Remove(school);
        //
        // await _dbContext.SaveChangesAsync();
        
    }

    [Benchmark]
    public async Task Delete_With_Execution()
    {
        var school = await _dbContext.Schools.FirstAsync();

        var studentIds = await _dbContext.Students
            .AsNoTracking()
            .Where(s => s.SchoolId == school.Id)
            .Select(s => s.Id)
            .ToListAsync();
        
        var teacherIds = await _dbContext.Teachers
            .AsNoTracking()
            .Where(s => s.SchoolId == school.Id)
            .Select(t => t.Id)
            .ToListAsync();
        
        var courseIds = await _dbContext.Courses
            .AsNoTracking()
            .Where(c => c.Students.Any(s => studentIds.Contains(s.Id)) || 
                        teacherIds.Contains(c.TeacherId))
            .Select(c => c.Id)
            .ToListAsync();

        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var parameters = courseIds.Select((id, index) => new SqlParameter($"@p{index}", id)).ToArray();
            
            var paramNames = string.Join(",", parameters.Select(p => p.ParameterName));

            var sql = $"DELETE FROM CourseStudent WHERE CoursesId IN ({paramNames})";

            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            
          await _dbContext.Courses
                .Where(c => courseIds.Contains(c.Id))
                .ExecuteDeleteAsync();
          
          await _dbContext.Teachers
                .Where(t => teacherIds.Contains(t.Id))
                .ExecuteDeleteAsync();
          
          await _dbContext.Students
                .Where(s => studentIds.Contains(s.Id))
                .ExecuteDeleteAsync();
          
          await _dbContext.Schools
                .Where(s => s.Id == school.Id)
                .ExecuteDeleteAsync();

          throw new Exception();

        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
        }
    }
}