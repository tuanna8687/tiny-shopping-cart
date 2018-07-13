namespace TinyShoppingCart.Domain.Entities
{
    public interface IVersionable
    {
        byte[] Version {get;set;}
    }
}