namespace MongoPractice.Domain.Aggregates;

public class ShList
{
    public ShList(Guid id, string name, IEnumerable<ShItem> items)
    {
        Id = id;
        Name = name;
        ShItems = items.ToList();
    }

    public Guid Id { get; init; }
    public string  Name { get; private set; }
    public List<ShItem> ShItems { get; private set; } = [];

}