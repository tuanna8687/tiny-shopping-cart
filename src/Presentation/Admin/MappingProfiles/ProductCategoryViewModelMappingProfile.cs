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
            CreateMap<ProductCategoryDTO, ProductCategoryViewModel>();
            CreateMap<EditProductCategoryViewModel, ProductCategoryDTO>();
            CreateMap<ProductCategory, EditProductCategoryViewModel>();
            CreateMap<EditProductCategoryDTO, EditProductCategoryViewModel>();
        }
    }
}