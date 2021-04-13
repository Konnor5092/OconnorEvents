using System.ComponentModel.DataAnnotations;

namespace OconnorEvents.ShoppingBasket.Dtos
{
    public class BasketLineForUpdateDto
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
