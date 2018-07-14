namespace TinyShoppingCart.Domain.Entities
{
    public class EntityWithTypedId<TIdentity> : IEntityWithTypedId<TIdentity> where TIdentity: struct
    {
        public TIdentity Id { get;set;}
    }
}