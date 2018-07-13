namespace TinyShoppingCart.Presentation.Admin.ViewModels
{
    public interface IViewModelWithTypedId<TIdentity>
    {
        TIdentity Id {get;set;}
    }
}