using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TinyShoppingCart.Domain.Entities;
using TinyShoppingCart.Domain.Repositories;
using TinyShoppingCart.Infrastructure.Persistence.Extensions;

namespace TinyShoppingCart.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : RepositoryWithTypedId<TEntity, int>, IRepository<TEntity>
        where TEntity : EntityWithTypedId<int> 
    {
        public Repository(TinyShoppingCartDbContext dbContext) : base(dbContext)
        {
        }
    }
}