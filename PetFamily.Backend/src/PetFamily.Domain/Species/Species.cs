using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Species : Entity<SpeciesId>
{
    public string Title { get; private set; } = null!;
    private readonly List<Breed> _breeds = [];
    public IReadOnlyList<Breed> Breeds => _breeds;

    private Species()
    {
        
    }
    public Species(SpeciesId id, string title) : base(id)
    {
        Title = title;
    }
    
    public static Result<Species> Create(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<Species>("Title is required");
        
        var species = new Species(SpeciesId.NewSpeciesId(), title);
        
        return Result.Success(species);
    }
}