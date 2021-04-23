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
    public class CreateBasketLine
    {
        public class Request : IRequest<BasketLineDto>
        {
            public Guid BasketId { get; set; }
            public BasketLineForCreationDto BasketLineForCreation { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(ShoppingBasketDbContext context)
            {
                RuleFor(x => x.BasketId).EntityExists(context, typeof(Basket));
                RuleFor(x => x.BasketLineForCreation.EventId).EntityExists(context, typeof(Event));
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
                var existingBasketLine = await _context.BasketLines
                    .Include(bl => bl.Event)
                    .Where(b => b.BasketId == request.BasketId && b.EventId == request.BasketLineForCreation.EventId)
                    .FirstOrDefaultAsync();

                if (existingBasketLine == null)
                {
                    var basketLineForCreation = new BasketLine
                    {
                        EventId = request.BasketLineForCreation.EventId,
                        TicketAmount = request.BasketLineForCreation.TicketAmount,
                        Price = request.BasketLineForCreation.Price
                    };

                    basketLineForCreation.BasketId = request.BasketId;

                    await _context.BasketLines.AddAsync(basketLineForCreation);

                    existingBasketLine = basketLineForCreation;
                } 
                else
                {
                    existingBasketLine.TicketAmount += request.BasketLineForCreation.TicketAmount;
                }
              
                await _context.SaveChangesAsync();

                var basket = await _context.Baskets
                    .Include(sb => sb.BasketLines)
                    .Where(b => b.Id == request.BasketId)
                    .FirstOrDefaultAsync();

                var basketChangeEvent = new BasketChangeEvent
                {
                    BasketChangeType = BasketChangeTypeEnum.Add,
                    EventId = request.BasketLineForCreation.EventId,
                    InsertedAt = DateTime.Now,
                    UserId = basket.UserId
                };

                await _context.BasketChangeEvents.AddAsync(basketChangeEvent);
                await _context.SaveChangesAsync();

                return new BasketLineDto
                {
                    BasketLineId = existingBasketLine.Id,
                    BasketId = existingBasketLine.BasketId,
                    EventId = existingBasketLine.EventId,
                    Price = existingBasketLine.Price,
                    TicketAmount = existingBasketLine.TicketAmount
                };
            }
        }
    }
}
