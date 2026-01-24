using MongoPractice.Contracts;
using MongoPractice.Domain;

namespace MongoPractice.Api.EndpointHandlers;

public static class ShListViewMapper
{
    public static ShListView ToView(this ShList shList)
        => new ShListView(shList.Id, shList.Name);
}