using AutoMapper;

using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Server.Presentation.Admin.MappingProfiles
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ViewProductCategoryViewModel>();
            CreateMap<EditProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductCategory, EditProductCategoryViewModel>();
        }
    }
}