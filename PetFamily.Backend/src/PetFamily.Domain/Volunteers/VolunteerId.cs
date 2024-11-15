namespace PetFamily.Domain.Volunteers;

public record VolunteerId
{
    public Guid Value { get; }
    public VolunteerId(Guid value)
    {
        Value = value;
    }
    public static VolunteerId NewVolunteerId() => new VolunteerId(Guid.NewGuid());
}