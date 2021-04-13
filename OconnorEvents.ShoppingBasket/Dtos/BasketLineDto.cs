﻿using System;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketLineDto
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid EventId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
        public Event Event { get; set; }
    }
}
