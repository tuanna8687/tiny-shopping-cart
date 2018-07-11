using Newtonsoft.Json;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public class ViewModelWithTypeId<TIdentity> : IViewModelWithTypedId<TIdentity>
    {
        [JsonProperty("Id")]
        public TIdentity Id { get;set;}
    }
}