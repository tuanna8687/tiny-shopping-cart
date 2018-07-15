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
        }
    }
}