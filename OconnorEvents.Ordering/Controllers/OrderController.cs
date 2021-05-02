using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.Mediatr.CollectionQuery;
using OconnorEvents.Ordering.Dtos;
using OconnorEvents.Ordering.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/{userId}")]
        public async Task<CollectionQueryResponse<OrderDto>> GetOrders(Guid userId, [FromQuery] IEnumerable<SortColumn>? sort,
           int pageSize = 100,
           int pageNumber = 0)
        {
            return await _mediator.Send(new GetOrders.Request()
            {
                PageSize = pageSize,
                Page = pageNumber,
                SortOrder = sort,
                UserId = userId
            });
        }
    }
}
