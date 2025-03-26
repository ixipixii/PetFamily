using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.VO;

public class PetPhoto : ComparableValueObject
{
    public string Path { get; }
    public bool? IsMainPhoto { get; }
    public PetPhoto(string path, bool? isMainPhoto)
    {
        Path = path;    
        IsMainPhoto = isMainPhoto;
    }
    
    public static PetPhoto NewPetPhoto(string path, bool isMainPhoto) => new PetPhoto(path, isMainPhoto);
    public static PetPhoto Empty => new PetPhoto(string.Empty, null);
    public static Result<PetPhoto, Error> Create(string path, bool? isMainPhoto)
    {
        if(string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");
        if(isMainPhoto == null)
            return Errors.General.ValueIsInvalid("IsMainPhoto");
        
        return new PetPhoto(path, isMainPhoto);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Path;
    }
}