using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.EventCatalog.Dtos;
using OconnorEvents.EventCatalog.Queries;
using OconnorEvents.Mediatr.CollectionQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Controllers
{
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<CollectionQueryResponse<EventDto>> GetEvents([FromQuery] Guid? categoryId,
            IEnumerable<SortColumn>? sort,
            int pageSize = 10,
            int pageNumber = 0)
        {
            return await _mediator.Send(new GetEvents.Request()
            {
                PageSize = pageSize,
                Page = pageNumber,
                SortOrder = sort,
                CategoryId = categoryId
            });
        }

        [HttpGet("{eventId}")]
        public async Task<EventDto> GetEventById(Guid eventId)
        {
            return await _mediator.Send(new GetEvent.Request()
            {
                EventId = eventId
            });
        }
    }
}
