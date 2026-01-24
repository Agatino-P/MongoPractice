namespace MongoPractice.Infrastructure.Database.Entities;

public class ShListEntity
{
    public object MongoId; //TODO: figure this out

    public ShListEntity(object mongoMongoId, Guid id, string name)
    {
        MongoId = mongoMongoId;
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string  Name { get; private set; }
}