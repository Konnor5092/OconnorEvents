using MediatR;
using System.Collections.Generic;

namespace OconnorEvents.Mediatr.CollectionQuery
{
    public abstract class CollectionQueryRequest<TItem> : IRequest<CollectionQueryResponse<TItem>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<SortColumn>? SortOrder { get; set; }
    }
}
