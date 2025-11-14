using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers.VO;

public class VolunteerId : ComparableValueObject
{
    public Guid Value { get; }
    public VolunteerId(Guid value)
    {
        Value = value;
    }
    public static VolunteerId Empty() => new VolunteerId(Guid.Empty);
    public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());
    public static VolunteerId Create(Guid id) => new(id);

    public static implicit operator Guid(VolunteerId volunteerId)
    {
        ArgumentNullException.ThrowIfNull(volunteerId);
        return volunteerId.Value;
    }
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}