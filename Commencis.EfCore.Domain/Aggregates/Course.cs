using Commencis.EfCore.Domain.Aggregates.Base;

namespace Commencis.EfCore.Domain.Aggregates;

public class Course : AggregateBase
{
    public string Name { get; set; }
    
    public Guid TeacherId { get; set; }
    
    public Teacher Teacher { get; set; }
    
    public List<Student> Students { get; set; } = [];
}