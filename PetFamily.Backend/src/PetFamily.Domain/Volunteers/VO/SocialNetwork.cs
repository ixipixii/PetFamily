using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public class SocialNetwork : ComparableValueObject
{
    public string Link { get; }
    public string Title { get; }
    
    public SocialNetwork(string link, string title)
    {
        Link = link;
        Title = title;
    }
    public static SocialNetwork NewAddress(string link, string title) => new SocialNetwork(link, title);
    public static SocialNetwork Empty => new SocialNetwork(string.Empty, String.Empty);

    public static Result<SocialNetwork> Create(string link, string title)
    {
        if(string.IsNullOrWhiteSpace(link))
            return Result.Failure<SocialNetwork>("Link is required");
        
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<SocialNetwork>("Title is required");
        
        var socialNetwork = new SocialNetwork(link, title);
        
        return Result.Success(socialNetwork);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Link;
    }
}