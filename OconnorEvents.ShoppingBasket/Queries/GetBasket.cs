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
    public class GetBasket
    {
        public class Request : IRequest<BasketDto>
        {
            public Guid BasketId { get; init; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(ShoppingBasketDbContext context)
            {
                RuleFor(x => x.BasketId).EntityExists(context, typeof(Basket));
            }
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
                var basketEntity = await _context.Baskets
                    .Include(sb => sb.BasketLines)
                    .Where(b => b.Id == request.BasketId)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                return new BasketDto
                {
                    BasketId = basketEntity.Id,
                    UserId = basketEntity.UserId,
                    NumberOfItems = basketEntity.BasketLines.Sum(bl => bl.TicketAmount),
                };
            }
        }
    }
}
