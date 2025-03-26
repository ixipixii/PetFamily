using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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

    public static Result<SocialNetwork, Error> Create(string link, string title)
    {
        if (string.IsNullOrWhiteSpace(link))
            return Errors.General.ValueIsInvalid(nameof(link));

        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid(nameof(title));

        return new SocialNetwork(link, title);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Link;
    }
}