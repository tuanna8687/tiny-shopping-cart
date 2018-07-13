namespace TinyShoppingCart.Domain.Entities
{
    public interface IQueryObject
    {
         string IncludeProperties {get;set;}
         bool IsTracking {get;set;}
         string Keyword {get;set;}
         string OrderBy {get;set;}
         bool IsOrderAscending {get;set;}
         int Start {get;set;}
         int PageSize {get;set;}
    }
}