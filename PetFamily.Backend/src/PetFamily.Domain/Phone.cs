namespace PetFamily.Domain;

public record Phone
{
    public string Number { get; }

    public Phone(string number)
    {
        Number = number;
    }
    
    public static Phone NewPhone(string number) => new Phone(number);
}