using System.Collections.Generic;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public interface IQueryResultViewModel<out T>
    {
        int Draw {get;set;}
        int RecordsTotal {get;set;}
        int RecordsFiltered {get;set;}
        IEnumerable<T> Data {get;}
        string Error {get;set;}
    }
}