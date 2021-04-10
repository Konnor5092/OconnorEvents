using MediatR;
using OconnorEvents.EventCatalog.Dtos;
using OconnorEvents.EventCatalog.Entities;
using OconnorEvents.Mediatr.CollectionQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.EventCatalog.Queries
{
    public class GetCategories
    {
        public class Request : CollectionQueryRequest<CategoryDto> { }

        public class Handler : CollectionQueryRequestHandler<Request, CategoryDto, Category>
        {
            private readonly EventCatalogDbContext _context;

            public Handler(EventCatalogDbContext context)
            {
                _context = context;
            }

            protected override Expression<Func<Category, object>> DefaultOrderBy()
            {
                return c => c.Name;
            }

            protected override Task<IQueryable<Category>> Filter(Request request)
            {
                return Task.FromResult(_context.Categories.AsQueryable());
            }

            protected override Expression<Func<Category, CategoryDto>> Map()
            {
                return c => new CategoryDto
                {
                    Name = c.Name,
                    CategoryId = c.Id
                };
            }

            protected override Dictionary<string, Expression<Func<Category, object>>> OrderByExpressions
            {
                get
                {
                    return new Dictionary<string, Expression<Func<Category, object>>>
                    {
                        ["name"] = c => c.Name,
                        ["categoryid"] = c => c.Id
                    };
                }
            }
        }
    }
}
