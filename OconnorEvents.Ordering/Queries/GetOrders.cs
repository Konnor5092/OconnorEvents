using FluentValidation;
using OconnorEvents.Mediatr.CollectionQuery;
using OconnorEvents.Ordering.Dtos;
using OconnorEvents.Ordering.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OconnorEvents.Ordering.Queries
{
    public class GetOrders
    {
        public class Request : CollectionQueryRequest<OrderDto>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : CollectionQueryRequestHandler<Request, OrderDto, Order>
        {
            private readonly OrderDbContext _context;

            public Handler(OrderDbContext context)
            {
                _context = context;
            }

            protected override Expression<Func<Order, object>> DefaultOrderBy()
            {
                return o => o.OrderPlaced;
            }

            protected override Task<IQueryable<Order>> Filter(Request request)
            {
                return Task.FromResult(_context.Orders.Where(o => o.UserId == request.UserId));
            }

            protected override Expression<Func<Order, OrderDto>> Map()
            {
                return o => new OrderDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderTotal = o.OrderTotal,
                    OrderPlaced = o.OrderPlaced,
                    OrderPaid = o.OrderPaid
                };
            }

            protected override Dictionary<string, Expression<Func<Order, object>>> OrderByExpressions
            {
                get
                {
                    return new Dictionary<string, Expression<Func<Order, object>>>
                    {
                        ["orderplaced"] = o => o.OrderPlaced,
                    };
                }
            }
        }
    }
}
