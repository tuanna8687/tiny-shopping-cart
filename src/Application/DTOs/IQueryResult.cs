using System.Collections.Generic;

namespace TinyShoppingCart.Application.DTOs
{
    public interface IQueryResultDTO<out T>
    {
        int TotalItems {get;set;}
        IEnumerable<T> Items {get;}
    }
}