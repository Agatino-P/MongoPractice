using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoPractice.Infrastructure.Database.Entities;

public class ShListEntity
{
    [BsonId] 
    public ObjectId MongoId { get; set; }
    
    public ShListEntity(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; init; }
    public string  Name { get; private set; }
}