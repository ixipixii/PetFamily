using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public class Phone : ComparableValueObject
{
    public string Number { get; }

    public Phone(string number)
    {
        Number = number;
    }
    
    public static Phone NewPhone(string number) => new Phone(number);
    public static Phone Empty => new Phone(string.Empty);

    public static Result<Phone, Error> Create(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return Errors.General.ValueIsInvalid(nameof(phone));
        
        phone = phone.Trim(); 

        if (!Regex.IsMatch(phone, @"^(?:\+7|8)\s*\(?\d{3}\)?[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}$"))
            return Errors.General.ValueIsRequired(nameof(phone));
        
        return new Phone(phone);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Number;
    }
}