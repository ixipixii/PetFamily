using CSharpFunctionalExtensions;

namespace PetFamily.Domain;

public class Volunteer
{
    #region Features

    public VolunteerId Id { get; private set; } = null!; //VO
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public int Experience { get; private set; }
    public Phone Phone { get; private set; } = null!; //VO
    private readonly List<Pet> _pets = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Requisite> _requisites = [];
    public IReadOnlyList<Pet> Pets => _pets;
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks; //VO
    public IReadOnlyList<Requisite> Requisite => _requisites; //VO

    #endregion

    #region Constructors

    public Volunteer(VolunteerId id, string fullName, string description)
    {
        Id = id;
        FullName = fullName;
        Description = description;
    }
    

    #endregion
    
    public static Result<Volunteer> Create(string fullName, string description)
    {
        if(string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<Volunteer>("FullName is required");
        
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<Volunteer>("Description is required");
        
        var volunteer = new Volunteer(VolunteerId.NewVolunteerId(), fullName, description);
        
        return Result.Success(volunteer);
    }

    #region Methods

    public int PetsThatHaveFoundAHome() => _pets.Count(p => p.HelpStatus == Pet.HelpStatuses.FoundHome);
    public int PetsThatLookingForAHome() => _pets.Count(p => p.HelpStatus == Pet.HelpStatuses.LookingForHome);
    public int PetsThatNeedHelp() => _pets.Count(p => p.HelpStatus == Pet.HelpStatuses.NeedHelp);

    #endregion
}