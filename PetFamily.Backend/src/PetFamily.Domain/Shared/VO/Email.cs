using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.VO;

public class Email : ComparableValueObject
{
    public string Address { get; }

    public Email(string address)
    {
        Address = address;
    }
    
    public static Email NewEmail(string address) => new Email(address);
    public static Email Empty => new Email(string.Empty);

    public static Result<Email, Error> Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            return Errors.General.ValueIsInvalid(nameof(address));
        
        address = address.Trim();

        if (!Regex.IsMatch(address, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            return Errors.General.ValueIsRequired(nameof(address));
        
        return new Email(address);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Address;
    }
}