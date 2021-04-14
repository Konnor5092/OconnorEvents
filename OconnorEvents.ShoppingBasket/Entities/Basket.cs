using OconnorEvents.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Entities
{
    public class Basket : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Collection<BasketLine> BasketLines { get; set; }

        public Guid? CouponId { get; set; }
    }
}
