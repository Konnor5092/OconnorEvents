using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public string Message { get; set; }
    }
}
