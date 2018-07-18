using AutoMapper;
using TinyShoppingCart.Application.DTOs;
using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Application.MappingProfiles
{
    public class ProductCategoryDTOMappingProfile : Profile
    {
        public ProductCategoryDTOMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, ProductCategory>()
                .ForMember(dest => dest.CreatedDate, src => src.Ignore())
                .ForMember(dest => dest.CreatedBy, src => src.Ignore());
            CreateMap<ProductCategory, EditProductCategoryDTO>();
        }
    }
}