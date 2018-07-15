using System;
using System.Linq.Expressions;

namespace TinyShoppingCart.Domain.Entities
{
    public interface IQueryOrder<TEntity, TProperty>
    {
         Expression<Func<TEntity, TProperty>> OrderBy {get;set;}
         bool IsOrderAscending {get;set;}
    }
}