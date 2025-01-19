using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteers.VO;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Entity<VolunteerId>
{
    #region Features
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
    public IReadOnlyList<Requisite> Requisites => _requisites; //VO

    #endregion

    #region Constructors

    //ef core
    private Volunteer()
    {
        
    }
    public Volunteer(VolunteerId volunteerId, string fullName, string description) : base(volunteerId)
    {
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