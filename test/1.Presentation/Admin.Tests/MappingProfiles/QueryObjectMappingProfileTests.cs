using System.Collections.Generic;
using AutoMapper;
using TinyShoppingCart.Server.Domain.Entities;
using TinyShoppingCart.Server.Presentation.Admin.MappingProfiles;
using TinyShoppingCart.Server.Presentation.Admin.ViewModels;
using Xunit;

namespace TinyShoppingCart.Server.Presentation.Admin.MappingProfiles
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