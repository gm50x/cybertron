using System;

namespace Cybertron.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDictRepository Dictionary { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
