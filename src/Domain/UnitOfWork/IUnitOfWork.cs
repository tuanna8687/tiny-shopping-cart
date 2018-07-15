using System;
using System.Threading.Tasks;
using TinyShoppingCart.Domain.Repositories;

namespace TinyShoppingCart.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoryRepository ProductCategoryRepository {get;}
        
        //  Task CommitAsync();
         void Commit();
    }
}