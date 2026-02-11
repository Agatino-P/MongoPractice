using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoPractice.Domain.Aggregates;

namespace MongoPractice.Infrastructure.Database.Entities;

public class ShItemEntity
{
    public ShItemEntity(Guid id, string name, int quantity, ShItemStatus status)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Status = status;
    }

    [BsonRepresentation(BsonType.String)] public Guid Id { get; init; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    
    [BsonRepresentation(BsonType.String)]
    public ShItemStatus Status { get; private set; }

    public static ShItemEntity FromShItem(ShItem shItem) =>
        new ShItemEntity(shItem.Id, shItem.Name, shItem.Quantity, shItem.Status);
}