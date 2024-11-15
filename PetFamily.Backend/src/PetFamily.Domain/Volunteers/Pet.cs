using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public class Pet : Shared.Entity<PetId>
{
    #region Features
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Species { get; private set; } = null!;
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
    
    public Requisite Requisite { get; private set; } = null!; //VO
    public DateTime CreationDate { get; private set; }
    
    public IReadOnlyList<PetPhoto> Photos { get; private set; } = []; //VO

    #endregion

    #region Constructors

    public Pet(PetId petId, string name, string description) : base(petId)
    {
        Name = name;
        Description = description;
    }

    //для ef
    private Pet(PetId petId) : base(petId)
    {
        
    }

    #endregion

    public static Result<Pet> Create(string name, string description)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name is required");
        
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description is required");
        
        var pet = new Pet(PetId.NewPetId(), name, description);
        
        return Result.Success(pet);
    }
}