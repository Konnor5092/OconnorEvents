using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.CollectionQuery
{
    public abstract class CollectionQueryRequest<TItem> : IRequest<CollectionQueryResponse<TItem>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<SortColumn>? SortOrder { get; set; }
    }
}
