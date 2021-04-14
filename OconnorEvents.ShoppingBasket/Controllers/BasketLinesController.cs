using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.ShoppingBasket.Commands;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLinesController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public BasketLinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<BasketLineDto> Get(Guid basketId, Guid basketLineId)
        {
            return await _mediator.Send(new GetBasketLine.Request()
            {
                BasketId = basketId,
                BasketLineId = basketLineId
            });
        }

        [HttpPost]
        public async Task<ActionResult<BasketLineDto>> Post(Guid basketId, [FromBody] BasketLineForCreationDto basketLineForCreation)
        {
            var (existingLine, basketLineDto) = await _mediator.Send(new CreateBasketLine.Request()
            {
                BasketId = basketId,
                BasketLineForCreation = basketLineForCreation
            });

            return CreatedAtRoute(
                "GetBasketLine",
                new { basketId = existingLine.BasketId, basketLineId = existingLine.Id },
                basketLineDto);
        }
    }
}
