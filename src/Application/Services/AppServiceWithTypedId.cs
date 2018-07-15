using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyShoppingCart.Application.DTOs;
using TinyShoppingCart.Domain.UnitOfWork;

namespace TinyShoppingCart.Application.Services
{
    public class AppServiceWithTypedId<TDto, TKey> : IAppServiceWithTypedId<TDto, TKey>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppServiceWithTypedId(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TDto GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDto> Get(Expression<Func<TDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryResultDTO<TDto> GetPaged(Expression<Func<TDto, bool>> predicate, IQueryPagingDTO queryDto = null)
        {
            throw new NotImplementedException();
        }

        public void Add(TDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TDto dtpToDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(TDto dtoToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}