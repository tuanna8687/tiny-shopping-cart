using System;
using System.Threading.Tasks;

namespace TinyShoppingCart.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
         Task CommitAsync();
         void Commit();
    }
}