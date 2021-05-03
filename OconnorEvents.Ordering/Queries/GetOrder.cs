using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.Mediatr.Core.Validation;
using OconnorEvents.Ordering.Dtos;
using OconnorEvents.Ordering.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Queries
{
    public class GetOrder
    {
        public class Request : IRequest<OrderDetailsDto>
        {
            public Guid OrderId { get; init; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(OrderDbContext context)
            {
                RuleFor(x => x.OrderId).EntityExists(context, typeof(Order));
            }
        }

        public class Handler : IRequestHandler<Request, OrderDetailsDto>
        {
            private readonly OrderDbContext _context;

            public Handler(OrderDbContext context)
            {
                _context = context;
            }

            public async Task<OrderDetailsDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var orderEntity = await _context.Orders
                    .Include(o => o.OrderLines)
                    .Where(o => o.Id == request.OrderId)
                    .FirstOrDefaultAsync();

                return new OrderDetailsDto
                {
                    OrderId = orderEntity.Id,
                    OrderTotal = orderEntity.OrderTotal,
                    OrderPaid = orderEntity.OrderPaid,
                    OrderPlaced = orderEntity.OrderPlaced,
                    OrderLines = orderEntity.OrderLines.Select(ol => new OrderLineDetailsDto
                    {
                        OrderLineId = ol.Id,
                        Price = ol.Price,
                        TicketAmount = ol.TicketAmount,
                        EventName = ol.EventName,
                        EventDate = ol.EventDate,
                        VenueName = ol.VenueName,
                        VenueCity = ol.VenueCity,
                        VenueCountry = ol.VenueCountry
                    }).ToList()
                };
            }
        }
    }
}
