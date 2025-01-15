namespace PetFamily.Domain.Species;
using CSharpFunctionalExtensions;

public class Breed : Entity<BreedId>
{
    public string Title { get; private set; } = null!;

    private Breed()
    {
        
    }
    public Breed(BreedId id, string title) : base(id)
    {
        Title = title;
    }
    
    public static Result<Breed> Create(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<Breed>("Title is required");
        
        var breed = new Breed(BreedId.NewBreedId(), title);
        
        return Result.Success(breed);
    }
}