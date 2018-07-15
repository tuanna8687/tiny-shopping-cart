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
    public class RepositoryWithTypedId<TEntity, TKey> : IRepositoryWithTypedId<TEntity, TKey> 
        where TEntity : EntityWithTypedId<TKey> 
        where TKey: struct
    {
        protected readonly TinyShoppingCartDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryWithTypedId(TinyShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        #region Implement Interface

        public virtual TEntity GetById(TKey id, IQueryInclude queryObj = null)
        {
            if(queryObj == null)
            {
                return _dbSet.Find(id);
            }

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyTrackingInclude(queryObj);

            return query.SingleOrDefault(x => x.Id.Equals(id));
        }

        public virtual IEnumerable<TEntity> GetAll(IQueryInclude queryObj = null)
        {
            if(queryObj == null)
            {
                return _dbSet;
            }

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyTrackingInclude(queryObj);

            return query;
        }

        public virtual IEnumerable<TEntity> GetAll<TOrderProperty>(IQueryIncludeOrder<TEntity, TOrderProperty> queryObj = null)
        {
            if(queryObj == null)
            {
                return _dbSet;
            }

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyTrackingInclude(queryObj);

            query = query.ApplyOrdering(queryObj);

            return query;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, IQueryInclude queryObj = null)
        {
            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyFilter(predicate);

            if(queryObj == null)
            {
                return query;
            }

            query = query.ApplyTrackingInclude(queryObj);

            return query;
        }

        public virtual IEnumerable<TEntity> Get<TOrderProperty>(Expression<Func<TEntity, bool>> predicate, IQueryIncludeOrder<TEntity, TOrderProperty> queryObj = null)
        {
            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyFilter(predicate);

            if(queryObj == null)
            {
                return query;
            }

            query = query.ApplyTrackingInclude(queryObj);

            query = query.ApplyOrdering(queryObj);

            return query;
        }

        public virtual IQueryResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> predicate, IQueryPaging queryObj = null)
        {
            QueryResult<TEntity> result = new QueryResult<TEntity>();

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyFilter(predicate);

            if(queryObj == null)
            {
                result.TotalItems = query.Count();
                result.Items = query;

                return result;
            }

            result.TotalItems = query.Count();
            query = query.ApplyPaging(queryObj);
            result.Items = query;

            return result;
        }

        public virtual IQueryResult<TEntity> GetPaged<TOrderProperty>(Expression<Func<TEntity, bool>> predicate, IQueryObject<TEntity, TOrderProperty> queryObj = null)
        {
            QueryResult<TEntity> result = new QueryResult<TEntity>();

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyFilter(predicate);

            if(queryObj == null)
            {
                result.TotalItems = query.Count();
                result.Items = query;

                return result;
            }

            query = query.ApplyTrackingInclude(queryObj);

            query = query.ApplyOrdering(queryObj);
            
            result.TotalItems = query.Count();
            query = query.ApplyPaging(queryObj);
            result.Items = query;

            return result;
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        #endregion
    }
}