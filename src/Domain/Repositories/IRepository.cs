using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> 
        where TEntity: IEntityWithTypedId<TKey> 
        where TKey: struct
    {
        TEntity GetById(TKey id, IQueryObject queryObj = null);
        IEnumerable<TEntity> GetAll(IQueryObject queryObj = null);
        IQueryResult<TEntity> Get(Expression<Func<TEntity, bool>> predicate, IQueryObject queryObj = null);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TKey id);
        void Delete(TEntity entityToDelete);
    } 
}