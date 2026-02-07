namespace MongoPractice.Domain.Aggregates;

public class ShItem
{
    public ShItem(Guid id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity=quantity;
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public int  Quantity { get; private set; }
    
}