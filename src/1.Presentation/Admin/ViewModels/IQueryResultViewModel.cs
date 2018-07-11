using System.Collections.Generic;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public interface IQueryResultViewModel<out T>
    {
        int RecordsTotal {get;set;}
        int RecordsFiltered {get;set;}
        IEnumerable<T> Items {get;}
    }
}