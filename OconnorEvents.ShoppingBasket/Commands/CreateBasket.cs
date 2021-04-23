using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Commands
{
    public class CreateBasket
    {
        public class Request : IRequest<BasketDto>
        {
            public BasketForCreationDto BasketForCreation { get; set; }
        }

        public class Handler : IRequestHandler<Request, BasketDto>
        {
            private readonly ShoppingBasketDbContext _context;

            public Handler(ShoppingBasketDbContext context)
            {
                _context = context;
            }

            public async Task<BasketDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var basketEntity = await _context.Baskets.SingleOrDefaultAsync(b => b.UserId == request.BasketForCreation.UserId);

                if (basketEntity == null)
                {
                    basketEntity = new Basket
                    {
                        UserId = request.BasketForCreation.UserId
                    };

                    await _context.Baskets.AddAsync(basketEntity);
                    await _context.SaveChangesAsync();
                }           

                return new BasketDto
                {
                    BasketId = basketEntity.Id,
                    UserId = basketEntity.UserId
                };
            }
        }
    }
}
