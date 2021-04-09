using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.EventCatalog.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Queries
{
    public class GetEvent
    {
        public class Request : IRequest<EventDto> 
        {
            public Guid EventId { get; set; }
        }

        public class Handler : IRequestHandler<Request, EventDto>
        {
            private readonly EventCatalogDbContext _context;

            public Handler(EventCatalogDbContext context)
            {
                _context = context;
            }

            public async Task<EventDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var e = await _context.Events
                    .Include(x => x.Category)
                    .SingleOrDefaultAsync(x => x.EventId == request.EventId);

                return new EventDto
                {
                    EventId = e.EventId,
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
        }
    }
}
