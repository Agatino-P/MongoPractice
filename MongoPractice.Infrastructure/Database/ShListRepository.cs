using MongoPractice.Infrastructure.Database.Entities;
using System.Globalization;

namespace MongoPractice.Infrastructure.Database;

public class ShListRepository : IShListRepository
{
    private static readonly List<ShListEntity> _shListEntities = [];

    public async Task< Either<Error, ShList>> GetById(Guid id)
    {
        await Task.CompletedTask;
        Option<ShListEntity> optionalEntity=Optional(_shListEntities.FirstOrDefault(x => x.Id == id));
        
        Either<Error, ShList> either = 
            optionalEntity.ToEither(Error.New($"ShList with id {id} Not found"))
                .Map(toShList);

        return either;
    }

    public async Task< Either<Error, Unit>> Add(ShList shList)
    {
        await Task.CompletedTask;

        if (_shListEntities.Exists(x => x.Id == shList.Id))
        {
            return Error.New($"ShList with id {shList.Id} already exists");
        }
        
        _shListEntities.Add(toShListEntity(shList));
        
        return Unit.Default;
    }


    private static ShList toShList(ShListEntity entity)
    {
        return new ShList(entity.Id, entity.Name);
    }
    
    private static ShListEntity toShListEntity(ShList shList)
    {
        object newMongoId = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        return new ShListEntity(newMongoId,shList.Id,shList.Name);
    }

}