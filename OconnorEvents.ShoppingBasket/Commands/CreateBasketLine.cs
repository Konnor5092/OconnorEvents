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
        public class Request : IRequest<(BasketLine, BasketLineDto)>
        {
            public Guid BasketId { get; set; }
            public BasketLineForCreationDto BasketLineForCreation { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(ShoppingBasketDbContext context)
            {
                RuleFor(x => x.BasketId).EntityExists(context, typeof(Basket));
            }
        }

        public class Handler : IRequestHandler<Request, (BasketLine, BasketLineDto)>
        {
            private readonly ShoppingBasketDbContext _context;
            private readonly HttpClient _client;

            public Handler(ShoppingBasketDbContext context, HttpClient client)
            {
                _context = context;
                _client = client;
            }

            public async Task<(BasketLine, BasketLineDto)> Handle(Request request, CancellationToken cancellationToken)
            {
                if (!await _context.Events.AnyAsync(e => e.Id == request.BasketLineForCreation.EventId))
                {
                    var response = await _client.GetAsync($"/api/events/{request.BasketLineForCreation.EventId}");
                    var entityEvent = await response.ReadContentAs<Event>();
                    _context.Events.Add(entityEvent);
                    await _context.SaveChangesAsync();
                }

                var basketLineEntity = new BasketLine
                {
                    EventId = request.BasketLineForCreation.EventId,
                    TicketAmount = request.BasketLineForCreation.TicketAmount,
                    Price = request.BasketLineForCreation.Price
                };

                var existingLine = await _context.BasketLines
                    .Include(bl => bl.Event)
                    .Where(b => b.BasketId == request.BasketId && b.EventId == basketLineEntity.EventId)
                    .FirstOrDefaultAsync();

                if (existingLine == null)
                {
                    basketLineEntity.BasketId = request.BasketId;
                    _context.BasketLines.Add(basketLineEntity);
                }

                existingLine.TicketAmount += basketLineEntity.TicketAmount;

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

                return (existingLine, new BasketLineDto
                {
                    BasketLineId = existingLine.Id,
                    BasketId = existingLine.BasketId,
                    EventId = existingLine.EventId,
                    Price = existingLine.Price,
                    TicketAmount = existingLine.TicketAmount
                });
            }
        }
    }
}
