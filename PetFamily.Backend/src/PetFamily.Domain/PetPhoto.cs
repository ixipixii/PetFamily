using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain;

public record PetPhoto
{
    public string Path { get; }
    public bool? IsMainPhoto { get; }
    public PetPhoto(string path, bool? isMainPhoto)
    {
        Path = path;    
        IsMainPhoto = isMainPhoto;
    }
    
    public static Result<PetPhoto> Create(string path, bool? isMainPhoto)
    {
        if(string.IsNullOrWhiteSpace(path))
            return Result.Failure<PetPhoto>("Path is required");
        if(isMainPhoto == null)
            return Result.Failure<PetPhoto>("Photo is required");
        
        var phone = new PetPhoto(path, isMainPhoto);
        
        return Result.Success(phone);
    }
}