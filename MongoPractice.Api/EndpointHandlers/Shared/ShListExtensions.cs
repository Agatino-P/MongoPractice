using MongoPractice.Contracts;
using MongoPractice.Contracts.V1.Views;
using MongoPractice.Domain;

namespace MongoPractice.Api.EndpointHandlers;

public static class ShListExtensions
{
    public static ShListViewV1 ToView(this ShList shList)
        => new ShListViewV1(shList.Id, shList.Name);
}