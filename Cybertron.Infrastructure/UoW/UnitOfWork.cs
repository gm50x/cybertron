using Cybertron.Infrastructure.Interfaces;
using Cybertron.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Cybertron.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _conn;
        private IDbTransaction _transaction;
        private Dictionary<string, IRepository> _repositories;

        public UnitOfWork(IDbConnection conn)
        {
            _conn = conn;
        }
        public void BeginTransaction()
        {
            _conn.Open();
            _transaction = _conn.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
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

        public T GetRepository<T>()
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, IRepository>();

            var type = typeof(T);
            var repositoryName = type.IsInterface ? type.Name.Substring(1) : type.Name;
            if (!_repositories.ContainsKey(repositoryName))
            {
                var assembly = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(x => x.Name == repositoryName);

                var repository = (Repository)Activator
                    .CreateInstance(assembly, _conn);

                _repositories.Add(repositoryName, repository);
            }
            return (T)_repositories[repositoryName];
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }
    }
}
