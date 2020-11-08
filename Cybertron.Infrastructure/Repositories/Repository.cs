using Cybertron.Infrastructure.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Cybertron.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _conn;
        public Repository(IDbConnection conn)
        {
            _conn = conn;
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters = null)
        {
            return await _conn.QueryAsync<T>(query, parameters);
        }

        protected async Task<T> QuerySingleAsync<T>(string query, object parameters = null)
        {
            return await _conn.QuerySingleAsync<T>(query, parameters);
        }

        protected async Task<T> QueryFirstAsync<T>(string query, object parameters = null)
        {
            return await _conn.QueryFirstAsync<T>(query, parameters);
        }

        protected async Task ExecuteAsync(string query, object parameters = null)
        {
            await _conn.ExecuteAsync(query, parameters);
        }
    }
}
