using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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
    public static Result<Address, Error> Create(string nameAddress)
    {
        if(string.IsNullOrWhiteSpace(nameAddress))
            return Errors.General.ValueIsInvalid("Address");
        return new Address(nameAddress);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return NameAddress;
    }
}