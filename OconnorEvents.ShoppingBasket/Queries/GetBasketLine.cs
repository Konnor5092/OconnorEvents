using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.Mediatr.Core.Validation;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Queries
{
    public class GetBasketLine
    {
        public class Request : IRequest<BasketLineDto>
        {
            public Guid BasketId { get; init; }
            public Guid BasketLineId { get; init; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(ShoppingBasketDbContext context)
            {
                RuleFor(x => x.BasketId).EntityExists(context, typeof(Basket));
                RuleFor(x => x.BasketLineId).EntityExists(context, typeof(BasketLine));
            }
        }

        public class Handler : IRequestHandler<Request, BasketLineDto>
        {
            private readonly ShoppingBasketDbContext _context;

            public Handler(ShoppingBasketDbContext context)
            {
                _context = context;
            }

            public async Task<BasketLineDto> Handle(Request request, CancellationToken cancellationToken)
            {
                await _context.Baskets.AnyAsync(b => b.Id == request.BasketId, cancellationToken: cancellationToken);

                var basketLineEntity = await _context.BasketLines
                    .Include(bl => bl.Event)
                    .Where(b => b.Id == request.BasketLineId)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                return new BasketLineDto
                {
                    BasketId = basketLineEntity.Id,
                };
            }
        }
    }
}
