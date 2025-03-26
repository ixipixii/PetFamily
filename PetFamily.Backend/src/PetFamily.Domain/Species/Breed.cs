using PetFamily.Domain.Shared;

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
    
    public static Result<Breed, Error> Create(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid(nameof(title));
        
        return new Breed(BreedId.NewBreedId(), title);
    }
}