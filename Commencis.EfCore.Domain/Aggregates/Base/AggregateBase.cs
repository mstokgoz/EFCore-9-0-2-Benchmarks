namespace Commencis.EfCore.Domain.Aggregates.Base;

public class AggregateBase
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastModificationTime { get; set; }
}