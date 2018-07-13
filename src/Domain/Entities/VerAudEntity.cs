namespace TinyShoppingCart.Domain.Entities
{
    public class VerAudEntity : AudEntity, IVersionable
    {
        public byte[] Version { get;set; }
    }
}