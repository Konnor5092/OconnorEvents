﻿using OconnorEvents.ShoppingBasket.Entities;
using System;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketChangeEventForPublicationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTimeOffset InsertedAt { get; set; }
        public BasketChangeTypeEnum BasketChangeType { get; set; }
    }
}
