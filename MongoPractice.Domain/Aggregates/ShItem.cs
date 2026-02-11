namespace MongoPractice.Domain.Aggregates;

public class ShItem
{
    public ShItem(Guid id, string name, int quantity, ShItemStatus status)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Status = status;
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public ShItemStatus Status { get; private set; }
}