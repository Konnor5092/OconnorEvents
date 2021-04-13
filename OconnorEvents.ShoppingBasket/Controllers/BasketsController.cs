using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using OconnorEvents.ShoppingBasket.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("{basketId}", Name = "GetBasket")]
        public async Task<Basket> Get(Guid basketId)
        {
            return await _mediator.Send(new GetBasket.Request()
            {
                BasketId = basketId
            });
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> Post(BasketForCreationDto basketForCreation)
        {
            return Ok();
        }
    }
}
