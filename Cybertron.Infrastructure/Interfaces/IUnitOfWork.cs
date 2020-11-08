namespace Cybertron.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        T GetRepository<T>();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
