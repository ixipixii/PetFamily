namespace PetFamily.Domain.Volunteers;

public record Address
{
    public string Adress { get; }

    public Address(string address)
    {
        Adress = address;
    }
    
    public static Address NewAddress(string address) => new Address(address);
}