using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteers.VO;

namespace PetFamily.Domain.Volunteers;

public class Pet : CSharpFunctionalExtensions.Entity<PetId>
{
    #region Features
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public SpeciesId Species { get; private set; } = null!; //VO
    public BreedId Breed { get; private set; } = null!; //VO
    public string Color { get; private set; } = null!;
    public string Health { get; private set; } = null!;
    public Address Address { get; private set; } = null!; //VO
    public string Weight { get; private set; } = null!;
    public string Growth { get; private set; } = null!;
    public Phone Phone { get; private set; } = null!; //VO
    public bool Castrated { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Vaccinated { get; private set; }
    public HelpStatuses HelpStatus { get; private set; }
    public enum HelpStatuses
    {
        FoundHome,
        LookingForHome,
        NeedHelp
    } 
    private readonly List<PetPhoto> _photos = [];
    private readonly List<Requisite> _requisites = [];
    public IReadOnlyList<Requisite> Requisites => _requisites; //VO
    public IReadOnlyList<PetPhoto> Photos => _photos; //VO
    public DateTime CreationDate { get; private set; }
    #endregion

    #region Constructors

    public Pet(PetId petId, string name, string description) : base(petId)
    {
        Name = name;
        Description = description;
    }

    //для ef
    private Pet()
    {
        
    }

    #endregion

    public static Result<Pet, Error> Create(string name, string description)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid(nameof(name));
        
        if(string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid(nameof(description));
        
        return new Pet(PetId.NewPetId(), name, description);
    }
}