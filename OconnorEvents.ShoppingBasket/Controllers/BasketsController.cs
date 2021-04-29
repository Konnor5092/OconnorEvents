using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.ShoppingBasket.Commands;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using OconnorEvents.ShoppingBasket.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{basketId:guid}", Name = "GetBasket")]
        public async Task<BasketDto> Get(Guid basketId)
        {
            return await _mediator.Send(new GetBasket.Request()
            {
                BasketId = basketId
            });
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> Post(BasketForCreationDto basketForCreation)
        {
            var basketToReturn = await _mediator.Send(new CreateBasket.Request()
            {
                BasketForCreation = basketForCreation
            });

            return CreatedAtRoute(
                "GetBasket",
                new { basketId = basketToReturn.BasketId },
                basketToReturn);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(BasketCheckoutDto basketCheckout)
        {
            return await _mediator.Send(new CheckoutBasket.Request()
            {
                BasketCheckout = basketCheckout
            });
        }
    }
}
