using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public interface IQueryObject<TEntity, TOrderProperty>: IQueryInclude, IQueryOrder<TEntity, TOrderProperty>, IQueryPaging
    {
    }
}