using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.EventCatalog.Dtos;
using OconnorEvents.EventCatalog.Entities;
using OconnorEvents.Mediatr.CollectionQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Queries
{
    public class GetEvents
    {
        public class Request : CollectionQueryRequest<EventDto> 
        {
            public Guid? CategoryId { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(x => x.CategoryId).NotEmpty();
            }
        }

        public class Handler : CollectionQueryRequestHandler<Request, EventDto, Event>
        {
            private readonly EventCatalogDbContext _context;

            public Handler(EventCatalogDbContext context)
            {
                _context = context;
            }

            protected override Expression<Func<Event, object>> DefaultOrderBy()
            {
                return c => c.Name;
            }

            protected override Task<IQueryable<Event>> Filter(Request request)
            {
                return Task.FromResult(_context.Events
                    .Include(x => x.Category)
                    .Where(x => (x.CategoryId == request.CategoryId || !request.CategoryId.HasValue)));
            }

            protected override Expression<Func<Event, EventDto>> Map()
            {
                return e => new EventDto
                {
                    EventId = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    Artist = e.Artist,
                    Date = e.Date,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    CategoryId = e.CategoryId,
                    CategoryName = e.Category.Name
                };
            }

            protected override Dictionary<string, Expression<Func<Event, object>>> OrderByExpressions
            {
                get
                {
                    return new Dictionary<string, Expression<Func<Event, object>>>
                    {
                        ["name"] = e => e.Name,
                        ["categoryname"] = e => e.Category.Name
                    };
                }
            }
        }
    }
}
