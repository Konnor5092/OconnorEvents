using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.CollectionQuery
{
    public abstract class CollectionQueryRequestHandler<TPagedQueryRequest, TItem, TEntity> : IRequestHandler<TPagedQueryRequest, CollectionQueryResponse<TItem>> where TPagedQueryRequest : CollectionQueryRequest<TItem>
    {
        public async Task<CollectionQueryResponse<TItem>> Handle(TPagedQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await Filter(request);
            IOrderedQueryable<TEntity>? orderedQuery = null;
            if (request.SortOrder != null)
            {
                foreach (var col in request.SortOrder)
                {
                    var colName = col.Name.ToLower();
                    if (!OrderByExpressions.ContainsKey(colName))
                    {
                        continue;
                    }

                    orderedQuery = StrongTypeOrderBy(OrderByExpressions[colName], orderedQuery, query, col.Direction);
                }
            }

            orderedQuery ??= StrongTypeOrderBy(DefaultOrderBy(), query);

            request.PageSize = request.PageSize < 0 ? 0 : request.PageSize;

            return new CollectionQueryResponse<TItem>()
            {
                Items = orderedQuery
                    .Skip(request.Page * request.PageSize)
                    .Take(request.PageSize)
                    .Select(Map()),
                TotalItems = query.Count()
            };
        }

        private IOrderedQueryable<TEntity> StrongTypeOrderBy(Expression<Func<TEntity, object>> orderByExpression, IQueryable<TEntity> query)
        {
            return StrongTypeOrderBy(orderByExpression, null, query, SortColumn.Directions.Ascending);
        }

        private IOrderedQueryable<TEntity> StrongTypeOrderBy(Expression<Func<TEntity, object>> orderByExpression, IOrderedQueryable<TEntity>? orderedQuery, IQueryable<TEntity> query, SortColumn.Directions direction)
        {
            var exprbody = orderByExpression.Body;
            if (exprbody.NodeType == ExpressionType.Convert)
            {
                exprbody = ((UnaryExpression)exprbody).Operand;
            }

            var expressionAsLambda = Expression.Lambda(exprbody, orderByExpression.Parameters);
            if (exprbody.Type == typeof(Guid))
            {
                var asexpression = (Expression<Func<TEntity, Guid>>)expressionAsLambda;
                orderedQuery = orderedQuery == null
                    ? ApplyOrderBy(query, asexpression, direction)
                    : ApplyThenBy(orderedQuery, asexpression, direction);
            }
            else if(exprbody.Type == typeof(DateTime))
            {
                var asexpression = (Expression<Func<TEntity, DateTime>>)expressionAsLambda;
                orderedQuery = orderedQuery == null
                    ? ApplyOrderBy(query, asexpression, direction)
                    : ApplyThenBy(orderedQuery, asexpression, direction);
            }
            else if (exprbody.Type == typeof(int))
            {
                var asexpression = (Expression<Func<TEntity, int>>)expressionAsLambda;
                orderedQuery = orderedQuery == null
                    ? ApplyOrderBy(query, asexpression, direction)
                    : ApplyThenBy(orderedQuery, asexpression, direction);
            }
            else if (exprbody.Type == typeof(string))
            {
                var asexpression = (Expression<Func<TEntity, string>>)expressionAsLambda;
                orderedQuery = orderedQuery == null
                    ? ApplyOrderBy(query, asexpression, direction)
                    : ApplyThenBy(orderedQuery, asexpression, direction);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return orderedQuery;
        }

        private IOrderedQueryable<TEntity> ApplyOrderBy<TKey>(IQueryable<TEntity> query, Expression<Func<TEntity, TKey>> expr, SortColumn.Directions direction)
        {
            switch (direction)
            {
                case SortColumn.Directions.Ascending:
                    return query.OrderBy(expr);
                case SortColumn.Directions.Descending:
                    return query.OrderByDescending(expr);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IOrderedQueryable<TEntity> ApplyThenBy<TKey>(IOrderedQueryable<TEntity> query, Expression<Func<TEntity, TKey>> expr, SortColumn.Directions direction)
        {
            switch (direction)
            {
                case SortColumn.Directions.Ascending:
                    return query.ThenBy(expr);
                case SortColumn.Directions.Descending:
                    return query.ThenByDescending(expr);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract Task<IQueryable<TEntity>> Filter(TPagedQueryRequest request);
        protected abstract Expression<Func<TEntity, TItem>> Map();
        protected abstract Expression<Func<TEntity, object>> DefaultOrderBy();

        protected virtual Dictionary<string, Expression<Func<TEntity, object>>> OrderByExpressions { get; } = new Dictionary<string, Expression<Func<TEntity, object>>>();
    }
}
