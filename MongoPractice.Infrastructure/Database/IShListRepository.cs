namespace MongoPractice.Infrastructure.Database;

public interface IShListRepository
{
    Task< Either<Error, ShList>> GetById(Guid id);
    Task< Either<Error, Unit>> Add(ShList shList);
}