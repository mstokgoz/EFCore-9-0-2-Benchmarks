namespace Commencis.EfCore.Domain.ValueObjects;

public class ContactInfo : ValueObject
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhoneNumber;
        yield return Email;
    }
}