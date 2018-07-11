using System;
using System.Threading.Tasks;

namespace TinyShoppingCart.Server.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
         Task CommitAsync();
         void Commit();
    }
}