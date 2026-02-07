using MongoPractice.Domain.Aggregates;

namespace MongoPractice.Infrastructure.Database.Repositories;

public interface IShListRepository
{
    Task< Either<Error, ShList>> GetById(Guid id);
    Task< Either<Error, Unit>> Add(ShList shList);
}