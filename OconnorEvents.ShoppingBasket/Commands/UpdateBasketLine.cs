using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.Core;
using OconnorEvents.Mediatr.Core.Validation;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Commands
{
    public class UpdateBasketLine
    {
        public class Request : IRequest<BasketLineDto>
        {
            public Guid BasketId { get; set; }
            public Guid BasketLineId { get; init; }
            public int Quantity { get; init; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(ShoppingBasketDbContext context)
            {
                RuleFor(x => x.BasketId).EntityExists(context, typeof(Basket));
                RuleFor(x => x.BasketLineId).EntityExists(context, typeof(BasketLine));
                RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
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
                var basketLine = await _context.BasketLines
                    .Include(b => b.Basket)
                    .Where(b => b.Id == request.BasketLineId)
                    .FirstOrDefaultAsync();

                basketLine.TicketAmount = request.Quantity;

                var basketChangeEvent = new BasketChangeEvent
                {
                    BasketChangeType = BasketChangeTypeEnum.Update,
                    EventId = basketLine.EventId,
                    InsertedAt = DateTime.Now,
                    UserId = basketLine.Basket.UserId
                };

                await _context.BasketChangeEvents.AddAsync(basketChangeEvent);
                await _context.SaveChangesAsync();
               
                return new BasketLineDto
                {
                    BasketLineId = basketLine.Id,
                    BasketId = basketLine.BasketId,
                    EventId = basketLine.EventId,
                    Price = basketLine.Price,
                    TicketAmount = basketLine.TicketAmount
                };
            }
        }
    }
}
