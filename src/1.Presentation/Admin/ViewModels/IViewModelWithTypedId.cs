namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public interface IViewModelWithTypedId<TIdentity>
    {
        TIdentity Id {get;set;}
    }
}