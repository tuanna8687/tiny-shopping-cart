namespace TinyShoppingCart.Domain.Entities
{
    public interface IEntityWithTypedId<TIdentity> where TIdentity: struct
    {
         TIdentity Id {get;set;}
    }
}