using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Presentation.Admin.ViewModels;

namespace TinyShoppingCart.Presentation.Admin.MappingProfiles
{
    public class QueryResultMappingProfile : Profile
    {
        public QueryResultMappingProfile()
        {
            CreateMap(typeof(IQueryResult<>), typeof(QueryResultViewModel<>))
                .ForMember("RecordsTotal", opt => opt.MapFrom("TotalItems"))
                .AfterMap(CustomMap);
        }

        public void CustomMap(object src, object des)
        {
            var srcInstance = src as IQueryResult<object>;
            var desInstance = des as IQueryResultViewModel<object>;

            if(srcInstance != null && desInstance != null)
            {
                desInstance.RecordsFiltered = srcInstance.Items.Select(x => x).Count();
            }
        }
    }

}