using AutoMapper;

using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Presentation.Admin.MappingProfiles
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