using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

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

    public static Result<Phone> Create(string number)
    {
        if(string.IsNullOrWhiteSpace(number))
            return Result.Failure<Phone>("Number is required");

        if (!Regex.IsMatch(number, @"^(?:\+7|8)\s*\(?\d{3}\)?[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}$"))
            return Result.Failure<Phone>("Invalid phone number");
        
        var phone = new Phone(number);
        
        return Result.Success(phone);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Number;
    }
}