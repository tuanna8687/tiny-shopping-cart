using System;
using AutoMapper;
using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Server.Presentation.Admin.MappingProfiles
{
    public class QueryObjectMappingProfile : Profile
    {
        public QueryObjectMappingProfile()
        {
            CreateMap<DataTableParamViewModel, QueryObject>()
                .ForMember(des => des.Keyword, opt => opt.MapFrom(src => src.Search.Value))
                .ForMember(des => des.PageSize, opt => opt.MapFrom(src => src.Length))
                .AfterMap(CustomMap);
        }

        public void CustomMap(DataTableParamViewModel src, QueryObject des)
        {
            var columnIndex = -1;
            if(src.Order != null && src.Order.Count > 0 && src.Columns != null && src.Columns.Count > 0)
            {
                columnIndex = src.Order[0].Column;
                var orderByColumnName = src.Columns[columnIndex].Name;
                des.OrderBy = orderByColumnName;
                des.IsOrderAscending = src.Order[0].Dir.Equals("asc", StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }
}