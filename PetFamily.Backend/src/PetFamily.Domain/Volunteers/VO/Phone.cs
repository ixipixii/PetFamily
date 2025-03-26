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

    public static Result<Phone, Error> Create(string number)
    {
        if(string.IsNullOrWhiteSpace(number))
            return Errors.General.ValueIsInvalid(nameof(number));

        if (!Regex.IsMatch(number, @"^(?:\+7|8)\s*\(?\d{3}\)?[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}$"))
            return Errors.General.ValueIsRequired(nameof(number));
        
        return new Phone(number);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Number;
    }
}