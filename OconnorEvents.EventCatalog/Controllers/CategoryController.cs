using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OconnorEvents.EventCatalog.Dtos;
using OconnorEvents.EventCatalog.Queries;
using OconnorEvents.Mediatr.CollectionQuery;

namespace OconnorEvents.EventCatalog.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<CollectionQueryResponse<CategoryDto>> Get(     
            IEnumerable<SortColumn>? sort, 
            int pageSize = 10,
            int pageNumber = 0)
        {
            return await _mediator.Send(new GetCategories.Request()
            {
                PageSize = pageSize,
                Page = pageNumber,
                SortOrder = sort
            });
        }
    }
}
