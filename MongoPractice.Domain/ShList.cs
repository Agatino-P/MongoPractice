namespace MongoPractice.Domain;

public class ShList
{
    public ShList(Guid id, string name="New Shopping List")
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string  Name { get; private set; }
    
}