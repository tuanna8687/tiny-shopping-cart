namespace TinyShoppingCart.Server.Domain.Entities
{
    public interface IVersionable
    {
        byte[] Version {get;set;}
    }
}