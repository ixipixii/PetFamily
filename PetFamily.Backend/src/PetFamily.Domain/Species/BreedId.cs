using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class BreedId : ComparableValueObject
{
    public Guid Value { get; }
    public BreedId(Guid value)
    {
        Value = value;
    }
    public static BreedId Empty() => new BreedId(Guid.Empty);
    public static BreedId NewBreedId() => new(Guid.NewGuid());
    public static BreedId Create(Guid id) => new(id);
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}