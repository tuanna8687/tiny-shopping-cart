using System;
using AutoMapper;
using DataTables.AspNet.Core;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Presentation.Admin.MappingProfiles
{
    public class QueryObjectMappingProfile : Profile
    {
        // public QueryObjectMappingProfile()
        // {
        //     CreateMap<IDataTablesRequest, QueryObject>()
        //         .ForMember(des => des.Keyword, opt => opt.MapFrom(src => src.Search.Value))
        //         .ForMember(des => des.PageSize, opt => opt.MapFrom(src => src.Length))
        //         .AfterMap(CustomMap);
        // }

        // public void CustomMap(IDataTablesRequest src, QueryObject des)
        // {
        //     foreach (var column in src.Columns)
        //     {
        //         if(column.IsSortable && column.Sort != null)
        //         {
        //             des.OrderBy = column.Name;
        //             des.IsOrderAscending = column.Sort.Direction == SortDirection.Ascending;
        //             break;
        //         }
        //     }
        // }
    }
}