using CSharpFunctionalExtensions;

namespace PetFamily.Domain;

public record Requisite
{
    public string Title { get; }
    public string Description { get; }
    public Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public static Result<Requisite> Create(string title, string description)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<Requisite>("Title is required");
        
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<Requisite>("Description is required");
        
        var requisite = new Requisite(title, description);
        
        return Result.Success(requisite);
    }
}