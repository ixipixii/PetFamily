using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.VO;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Shared.Entity<VolunteerId>
{
    #region Features
    public string FullName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public string? Description { get; private set; }
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
    public Volunteer(VolunteerId volunteerId, 
                     string fullName, Email email, 
                     Phone phone, 
                     List<SocialNetwork> socialNetworks, 
                     List<Requisite> requisites) 
        : base(volunteerId)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        _socialNetworks = socialNetworks;
        _requisites = requisites;
    }
    

    #endregion
    
    /*public static Result<Volunteer, Error> Create(string fullName, 
                                                  Email email, 
                                                  Phone phone,
                                                  List<SocialNetwork> socialNetworks,
                                                  List<Requisite> requisites)
    {
        return new Volunteer(VolunteerId.NewVolunteerId(), 
                                fullName, 
                                email,
                                phone,
                                socialNetworks,
                                requisites);
    }*/

    #region Methods

    public int PetsThatHaveFoundAHome() => _pets.Count(p => p.HelpStatus == Pet.HelpStatuses.FoundHome);
    public int PetsThatLookingForAHome() => _pets.Count(p => p.HelpStatus == Pet.HelpStatuses.LookingForHome);
    public int PetsThatNeedHelp() => _pets.Count(p => p.HelpStatus == Pet.HelpStatuses.NeedHelp);

    #endregion
}