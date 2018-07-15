namespace TinyShoppingCart.Application.Services
{
    public interface IAppService<TDto> : IAppServiceWithTypedId<TDto, int>
    {
         
    }
}