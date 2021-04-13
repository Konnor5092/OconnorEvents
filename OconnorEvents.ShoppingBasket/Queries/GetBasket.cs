using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Queries
{
    public class GetBasket
    {
        public class Request : IRequest<Basket>
        {
            public Guid BasketId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Basket>
        {
            private readonly ShoppingBasketDbContext _context;

            public Handler(ShoppingBasketDbContext context)
            {
                _context = context;
            }

            public async Task<Basket> Handle(Request request, CancellationToken cancellationToken)
            {
                return await _context.Baskets
                    .Include(sb => sb.BasketLines)
                    .Where(b => b.BasketId == request.BasketId)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
