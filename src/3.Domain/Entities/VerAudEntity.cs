namespace TinyShoppingCart.Server.Domain.Entities
{
    public class VerAudEntity : AudEntity, IVersionable
    {
        public byte[] Version { get;set; }
    }
}