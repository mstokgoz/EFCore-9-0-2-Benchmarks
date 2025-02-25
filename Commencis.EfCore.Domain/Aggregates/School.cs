using Commencis.EfCore.Domain.Aggregates.Base;
using Commencis.EfCore.Domain.ValueObjects;

namespace Commencis.EfCore.Domain.Aggregates;

public class School : AggregateBase
{
    public string Name { get; set; }
    
    public Address Address { get; set; }
    
    public ContactInfo ContactInfo { get; set; }
    
    public List<Teacher> Teachers { get; set; } = [];
    
    public List<Student> Students { get; set; } = [];
}