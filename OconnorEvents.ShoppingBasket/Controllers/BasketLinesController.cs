using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.ShoppingBasket.Commands;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
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

        [HttpGet]
        public async Task<IEnumerable<BasketLineShoppingBasketDto>> GetBasketLines(Guid basketId)
        {
            return await _mediator.Send(new GetBasketLines.Request()
            {
                BasketId = basketId
            });
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<BasketLineDto> GetBasketLine(Guid basketId, Guid basketLineId)
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
            var basketLineDto = await _mediator.Send(new CreateBasketLine.Request()
            {
                BasketId = basketId,
                BasketLineForCreation = basketLineForCreation
            });

            return CreatedAtRoute(
                "GetBasketLine",
                new { basketId = basketLineDto.BasketId, basketLineId = basketLineDto.BasketLineId },
                basketLineDto);
        }

        [HttpGet]
        [Route("total")]
        public async Task<int> GetTotal(Guid basketId)
        {
            return await _mediator.Send(new GetTotal.Request()
            {
                BasketId = basketId
            });
        }
    }
}
