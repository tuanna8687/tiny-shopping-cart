using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyShoppingCart.Domain.Entities;

namespace TinyShoppingCart.Domain.Repositories
{
    public interface IRepositoryWithTypedId<TEntity, TKey> 
        where TEntity: IEntityWithTypedId<TKey> 
        where TKey: struct
    {
        TEntity GetById(TKey id, IQueryInclude queryObj = null);
        IEnumerable<TEntity> GetAll(IQueryInclude queryObj = null);
        IEnumerable<TEntity> GetAll<TOrderProperty>(IQueryIncludeOrder<TEntity, TOrderProperty> queryObj = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, IQueryInclude queryObj = null);
        IEnumerable<TEntity> Get<TOrderProperty>(Expression<Func<TEntity, bool>> predicate, IQueryIncludeOrder<TEntity, TOrderProperty> queryObj = null);
        IQueryResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> predicate, IQueryPaging queryObj = null);
        IQueryResult<TEntity> GetPaged<TOrderProperty>(Expression<Func<TEntity, bool>> predicate, IQueryObject<TEntity, TOrderProperty> queryObj = null);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TKey id);
        void Delete(TEntity entityToDelete);
    } 
}
