using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public interface IQueryIncludeOrder<TEntity, TOrderProperty>: IQueryInclude, IQueryOrder<TEntity, TOrderProperty>
    {
    }
}