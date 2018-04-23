namespace TinyShoppingCart.Server.Domain.Entities
{
    public class EntityWithTypeId<TIdentity> : IEntityWithTypedId<TIdentity>
    {
        public TIdentity Id { get;set;}
    }
}