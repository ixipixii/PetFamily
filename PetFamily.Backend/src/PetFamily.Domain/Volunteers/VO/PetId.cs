using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers.VO;

public class PetId : ComparableValueObject
{
    public Guid Value { get; }

    public PetId(Guid value)
    {
        Value = value;
    }

    public static PetId Empty => new PetId(Guid.Empty);
    public static PetId NewPetId() => new(Guid.NewGuid());
    public static PetId Create(Guid id) => new(id);

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}