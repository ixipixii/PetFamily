using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record Phone
{
    public string Number { get; }

    public Phone(string number)
    {
        Number = number;
    }
    
    public static Result<Phone> Create(string number)
    {
        if(string.IsNullOrWhiteSpace(number) && Regex.IsMatch(number, @"^(?:\+7|8)\s*\(?\d{3}\)?[\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}$"))
            return Result.Failure<Phone>("Number is required");
        
        var phone = new Phone(number);
        
        return Result.Success(phone);
    }
}