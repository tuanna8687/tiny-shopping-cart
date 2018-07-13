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
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity : EntityWithTypedId<TKey> 
        where TKey: struct
    {
        protected readonly TinyShoppingCartDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TinyShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
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

        public virtual IQueryResult<TEntity> Get(Expression<Func<TEntity, bool>> predicate, IQueryObject queryObj = null)
        {
            var result = new QueryResult<TEntity>();

            IQueryable<TEntity> query = _dbSet;

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if(queryObj == null)
            {
                result.TotalItems = query.Count();
                result.Items = query;

                return result;
            }

            query = query.ApplyTracking(queryObj);

            query = query.ApplyInclude(queryObj);

            //query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = query.Count();

            query = query.ApplyPaging(queryObj);

            result.Items = query;

            return result;
        }

        public virtual IEnumerable<TEntity> GetAll(IQueryObject queryObj = null)
        {
            var result = new QueryResult<ProductCategory>();

            if(queryObj == null)
            {
                return _dbSet;
            }

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyTracking(queryObj);

            query = query.ApplyInclude(queryObj);

            //query = query.ApplyOrdering(queryObj, columnsMap);

            return query;
        }

        public virtual TEntity GetById(TKey id, IQueryObject queryObj = null)
        {
            if(queryObj == null)
            {
                return _dbSet.Find(id);
            }

            IQueryable<TEntity> query = _dbSet;

            query = query.ApplyTracking(queryObj);

            query = query.ApplyInclude(queryObj);

            return query.SingleOrDefault(x => x.Id.Equals(id));
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}