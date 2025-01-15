using CSharpFunctionalExtensions;

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
    public static Result<PetPhoto> Create(string path, bool? isMainPhoto)
    {
        if(string.IsNullOrWhiteSpace(path))
            return Result.Failure<PetPhoto>("Path is required");
        if(isMainPhoto == null)
            return Result.Failure<PetPhoto>("Photo is required");
        
        var phone = new PetPhoto(path, isMainPhoto);
        
        return Result.Success(phone);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Path;
    }
}