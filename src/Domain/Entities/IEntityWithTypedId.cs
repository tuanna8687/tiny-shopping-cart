namespace TinyShoppingCart.Domain.Entities
{
    public interface IEntityWithTypedId<TIdentity>
    {
         TIdentity Id {get;set;}
    }
}