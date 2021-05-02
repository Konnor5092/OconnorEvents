using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; }
        public Guid? CouponId { get; set; }
    }
}
