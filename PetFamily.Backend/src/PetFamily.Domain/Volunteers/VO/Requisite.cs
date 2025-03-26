using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public class Requisite : ComparableValueObject
{
    public string Title { get; }
    public string Description { get; }
    public Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public static Requisite NewAddress(string title, string description) => new Requisite(title, description);
    public static Requisite Empty => new Requisite(string.Empty, string.Empty);
    
    public static Result<Requisite, Error> Create(string title, string description)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid(nameof(title));

        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid(nameof(description));
        
        return new Requisite(title, description);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Title;
    }
}