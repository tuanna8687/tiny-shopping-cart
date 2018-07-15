using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyShoppingCart.Application.DTOs;

namespace TinyShoppingCart.Application.Services
{
    public interface IAppServiceWithTypedId<TDto, TKey>
    {
        TDto GetById(TKey id);
        IEnumerable<TDto> GetAll();
        IEnumerable<TDto> Get(Expression<Func<TDto, bool>> predicate);
        IQueryResultDTO<TDto> GetPaged(Expression<Func<TDto, bool>> predicate, IQueryPagingDTO queryDto = null);
        void Add(TDto dto);
        void Update(TDto dtoToUpdate);
        void Delete(TKey id);
        void Delete(TDto dtpToDelete);
    }
}