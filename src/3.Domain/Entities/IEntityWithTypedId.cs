namespace TinyShoppingCart.Server.Domain.Entities
{
    public interface IEntityWithTypedId<TIdentity>
    {
         TIdentity Id {get;set;}
    }
}