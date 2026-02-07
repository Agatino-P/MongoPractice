using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoPractice.Domain.Aggregates;

namespace MongoPractice.Infrastructure.Database.Entities;

public class ShListEntity
{
    [BsonId] 
    public ObjectId MongoId { get; set; }
    
    public ShListEntity(Guid id, string name,List<ShItemEntity>? shItems)
    {
        Id = id;
        Name = name;
        ShItems=shItems??[];
    }

    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; init; }
    public string  Name { get; private set; }
    public List<ShItemEntity> ShItems { get; init; } = [];
    
    public static ShListEntity FromShList(ShList shList) =>
        new ShListEntity(shList.Id, shList.Name, shList.ShItems.Select(ShItemEntity.FromShItem).ToList());
}