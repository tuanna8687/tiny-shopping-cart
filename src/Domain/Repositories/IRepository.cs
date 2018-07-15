using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Domain.Repositories
{
    public interface IRepository<TEntity> : IRepositoryWithTypedId<TEntity, int> 
        where TEntity: IEntityWithTypedId<int>
    {
    }
}