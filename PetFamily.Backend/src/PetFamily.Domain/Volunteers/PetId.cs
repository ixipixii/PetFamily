namespace PetFamily.Domain.Volunteers;

public record PetId
{
    public Guid Value { get; }
    public PetId(Guid value)
    {
        Value = value;
    }
    public static PetId NewPetId() => new PetId(Guid.NewGuid());
}