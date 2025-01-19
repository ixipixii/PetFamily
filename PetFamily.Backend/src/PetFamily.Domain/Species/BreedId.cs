namespace PetFamily.Domain.Species;

public class BreedId : IComparable<BreedId>
{
    public Guid Value { get; }
    public BreedId(Guid value)
    {
        Value = value;
    }
    public static BreedId NewBreedId() => new(Guid.NewGuid());
    public static BreedId Create(Guid id) => new(id);
    
    public int CompareTo(BreedId? other)
    {
        return other is null ? 1 : Value.CompareTo(other.Value);
    }
}