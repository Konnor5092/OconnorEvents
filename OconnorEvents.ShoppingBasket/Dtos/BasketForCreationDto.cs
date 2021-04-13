using System;
using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketForCreationDto
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
