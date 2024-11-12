namespace PetFamily.Domain;

public record Requisite
{
    public string Title { get; }
    public string Description { get; }
    public Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public static Requisite NewRequisite(string title, string description) => new Requisite(title, description);
}