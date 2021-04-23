using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Queries
{
    public class GetBasketLines
    {
        public class Request : IRequest<IEnumerable<BasketLineShoppingBasketDto>>
        {
            public Guid BasketId { get; init; }
        }

        public class Handler : IRequestHandler<Request, IEnumerable<BasketLineShoppingBasketDto>>
        {
            private readonly ShoppingBasketDbContext _context;

            public Handler(ShoppingBasketDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<BasketLineShoppingBasketDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var basketLines = await _context.BasketLines
                    .Include(e => e.Event)
                    .Where(b => b.BasketId == request.BasketId)
                    .ToListAsync(cancellationToken: cancellationToken);

                return basketLines.Select(b => new BasketLineShoppingBasketDto
                {
                    EventName = b.Event.Name,
                    EventDate = b.Event.Date,
                    PricePerTicket = b.Price,
                    Quantity = b.TicketAmount,
                    Total = b.Price * b.TicketAmount
                });
            }
        }
    }
}
