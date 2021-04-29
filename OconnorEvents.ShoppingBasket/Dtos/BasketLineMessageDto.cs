using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketLineMessageDto
    {
        public Guid BasketLineId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}
