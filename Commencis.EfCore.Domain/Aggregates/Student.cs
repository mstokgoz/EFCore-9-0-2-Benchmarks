using Commencis.EfCore.Domain.Aggregates.Base;
using Commencis.EfCore.Domain.ValueObjects;

namespace Commencis.EfCore.Domain.Aggregates;

public class Student : AggregateBase
{
    public string Name { get; set; }
    
    public Address Address { get; set; }
    
    public ContactInfo ContactInfo { get; set; }
    
    public Guid SchoolId { get; set; }
    
    public School School { get; set; }
    
    public List<Course> Courses { get; set; } = [];
}