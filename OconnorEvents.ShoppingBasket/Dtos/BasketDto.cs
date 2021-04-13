using System;

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
