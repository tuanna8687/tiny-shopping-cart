using System.Collections.Generic;

namespace TinyShoppingCart.Server.Domain.Entities
{
    public interface IQueryResult<out T>
    {
        int TotalItems {get;set;}
        IEnumerable<T> Items {get;}
    }
}