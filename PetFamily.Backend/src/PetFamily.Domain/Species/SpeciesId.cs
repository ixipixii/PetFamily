using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class SpeciesId : ComparableValueObject
{
    public Guid Value { get; }
    public SpeciesId(Guid value)
    {
        Value = value;
    }
    public static SpeciesId Empty() => new SpeciesId(Guid.Empty);
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
    public static SpeciesId Create(Guid id) => new(id);
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}