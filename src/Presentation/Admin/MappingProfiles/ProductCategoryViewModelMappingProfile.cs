using AutoMapper;
using TinyShoppingCart.Application.DTOs;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Presentation.Admin.MappingProfiles
{
    public class ProductCategoryViewModelMappingProfile : Profile
    {
        public ProductCategoryViewModelMappingProfile()
        {
            CreateMap<ProductCategoryDTO, ViewProductCategoryViewModel>();
            CreateMap<EditProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductCategory, EditProductCategoryViewModel>();
        }
    }
}