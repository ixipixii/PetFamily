using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Volunteers.VO;

public class SpeciesBreed : ComparableValueObject
{
    public SpeciesId SpeciesId { get; }
    public BreedId BreedId { get; }

    public SpeciesBreed(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }

    public static Result<SpeciesBreed, Error> Create(SpeciesId speciesId, BreedId breedId)
    {
        if (speciesId == null)
            return Errors.General.ValueIsInvalid(nameof(speciesId));
        
        if (breedId == null)
            return Errors.General.ValueIsInvalid(nameof(breedId));
        
        return new SpeciesBreed(speciesId, breedId);
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return SpeciesId;
        yield return BreedId;
    }
}