using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Infrastructure.Database.DataSources.GetSummaries;

public interface IShListSummariesDataSource
{
    Task<Either<Error, IEnumerable<ShListSummaryViewV1>>> GetSummaries();
}