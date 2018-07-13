using System;

namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public interface IAuditable<TIdentity> where TIdentity: struct
    {
        DateTime CreatedDate {get;set;}
        TIdentity CreatedBy {get;set;}
        DateTime? ModifiedDate {get;set;}
        TIdentity? ModifiedBy {get;set;}
    }
}