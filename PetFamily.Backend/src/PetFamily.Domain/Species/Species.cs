using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Species : CSharpFunctionalExtensions.Entity<SpeciesId>
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
    
    public static Result<Species, Error> Create(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid(nameof(title));
        
        return new Species(SpeciesId.NewSpeciesId(), title);
    }
}