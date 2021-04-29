using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OconnorEvents.Mediatr.Core.Validation;
using OconnorEvents.MessagingBus;
using OconnorEvents.ShoppingBasket.Dtos;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Commands
{
    public class CheckoutBasket
    {
        public class Request : IRequest<IActionResult>
        {
            public BasketCheckoutDto BasketCheckout { get; init; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator(ShoppingBasketDbContext context)
            {
                RuleFor(x => x.BasketCheckout.BasketId).EntityExists(context, typeof(Basket));
            }
        }

        public class Handler : IRequestHandler<Request, IActionResult>
        {
            private readonly ShoppingBasketDbContext _context;
            private readonly IMessageBus _messageBus;

            public Handler(ShoppingBasketDbContext context, IMessageBus messageBus)
            {
                _context = context;
                _messageBus = messageBus;
            }

            public async Task<IActionResult> Handle(Request request, CancellationToken cancellationToken)
            {
                var basket = await _context.Baskets
                    .Include(sb => sb.BasketLines)
                    .SingleAsync(b => b.Id == request.BasketCheckout.BasketId);

                var basketCheckoutMessage = new BasketCheckoutMessageDto
                {
                    Id = Guid.NewGuid(),
                    CreationDateTime = DateTime.Now,
                    BasketId = request.BasketCheckout.BasketId,
                    FirstName = request.BasketCheckout.FirstName,
                    LastName = request.BasketCheckout.LastName,
                    Email = request.BasketCheckout.Email,
                    Address = request.BasketCheckout.Address,
                    ZipCode = request.BasketCheckout.ZipCode,
                    City = request.BasketCheckout.City,
                    Country = request.BasketCheckout.Country,
                    UserId = request.BasketCheckout.UserId,
                    CardNumber = request.BasketCheckout.CardName,
                    CardName = request.BasketCheckout.CardName,
                    CardExpiration = request.BasketCheckout.CardExpiration,
                    BasketLines = basket.BasketLines.Select(b => new BasketLineMessageDto
                    {
                        BasketLineId = b.Id,
                        Price = b.Price,
                        TicketAmount = b.TicketAmount
                    }).ToList(),
                    BasketTotal = basket.BasketLines.Sum(b => b.Price * b.TicketAmount)
                };

                var basketLinesToClear = _context.BasketLines.Where(b => b.BasketId == request.BasketCheckout.BasketId);
                _context.BasketLines.RemoveRange(basketLinesToClear);
                basket.CouponId = null;
             
                try
                {
                    await _context.SaveChangesAsync();
                    await _messageBus.PublishMessage(basketCheckoutMessage, "checkoutmessage");
                }
                catch (Exception ex)
                {
                    return new ObjectResult(ex.StackTrace) 
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }

                return new AcceptedResult()
                {
                    StatusCode = StatusCodes.Status201Created,
                    Value = basketCheckoutMessage
                };
            }
        }
    }
}
