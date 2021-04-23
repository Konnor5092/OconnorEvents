using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketLineShoppingBasketDto
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int PricePerTicket { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
