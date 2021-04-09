using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.CollectionQuery
{
    public class CollectionQueryResponse<TItem>
    {
        public IEnumerable<TItem> Items { get; set; } = new TItem[0];
        public int TotalItems { get; set; }
    }
}
