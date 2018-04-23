namespace TinyShoppingCart.Server.Domain.Entities
{
    public interface IQueryObject
    {
         string IncludeProperties {get;set;}
         string Keyword {get;set;}
         string OrderBy {get;set;}
         bool IsOrderAscending {get;set;}
         int Start {get;set;}
         int PageSize {get;set;}
    }
}