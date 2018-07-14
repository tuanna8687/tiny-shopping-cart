using System.Collections.Generic;
using AutoMapper;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Presentation.Admin.MappingProfiles;
using TinyShoppingCart.Presentation.Admin.ViewModels;
using Xunit;

namespace TinyShoppingCart.Presentation.Admin.MappingProfiles
{
    public class QueryObjectMappingProfileTests : IClassFixture<QueryObjectMappingProfileFixture>
    {
        private readonly IMapper _mapper;
        
        public QueryObjectMappingProfileTests(QueryObjectMappingProfileFixture fixture)
        {
            _mapper = fixture.Mapper;
        }
    }
}