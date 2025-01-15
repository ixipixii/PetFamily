using CSharpFunctionalExtensions;

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
    
    public static Result<Requisite> Create(string title, string description)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<Requisite>("Title is required");
        
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>("Description is required");
        
        var requisite = new Requisite(title, description);
        
        return Result.Success(requisite);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Title;
    }
}