using System.Data;
using Cybertron.Infrastructure.Interfaces;
using Cybertron.Infrastructure.Repositories;

namespace Cybertron.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _conn;
        private IDbTransaction _transaction;

        public UnitOfWork(IDbConnection conn)
        {
            _conn = conn;
        }

        private IDictRepository _dict;
        public IDictRepository Dictionary
        {
            get { return _dict ??= new DictRepository(_conn); }
        }

        public void Begin()
        {
            _conn.Open();
            _transaction = _conn.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            _conn.Close();
            _transaction = null;
        }
    }
}
