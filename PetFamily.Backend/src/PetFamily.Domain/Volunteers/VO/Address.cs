using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers.VO;

public class Address : ComparableValueObject
{
    public string NameAddress { get; }

    public Address(string nameAddress)
    {
        NameAddress = nameAddress;
    }
    public static Address NewAddress(string address) => new Address(address);
    public static Address Empty => new Address(string.Empty);
    public static Result<Address> Create(string nameAddress)
    {
        if(string.IsNullOrWhiteSpace(nameAddress))
            return Result.Failure<Address>("Address is required");
        
        var address = new Address(nameAddress);
        
        return Result.Success(address);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return NameAddress;
    }
}