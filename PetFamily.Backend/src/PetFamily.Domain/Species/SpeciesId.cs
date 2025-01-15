namespace PetFamily.Domain.Species;

public class SpeciesId : IComparable<SpeciesId>
{
    public Guid Value { get; }
    public SpeciesId(Guid value)
    {
        Value = value;
    }
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
    public static SpeciesId Create(Guid id) => new(id);
    
    public int CompareTo(SpeciesId? other)
    {
        return other is null ? 1 : Value.CompareTo(other.Value);
    }
}