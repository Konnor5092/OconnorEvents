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
    public class GetTotal
    {
        public class Request : IRequest<int>
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

        public class Handler : IRequestHandler<Request, int>
        {
            private readonly ShoppingBasketDbContext _context;

            public Handler(ShoppingBasketDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                return await _context.BasketLines
                    .Where(b => b.BasketId == request.BasketId)
                    .SumAsync(b => b.Price * b.TicketAmount, cancellationToken: cancellationToken);
            }
        }
    }
}
