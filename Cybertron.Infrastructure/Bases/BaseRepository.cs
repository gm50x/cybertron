using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertron.Infrastructure.Bases
{
    public abstract class BaseRepository
    {
        private readonly IDbConnection _conn;

        public BaseRepository(IDbConnection conn)
        {
            _conn = conn;

        }

        public async Task<List<T>> QueryAsync<T>(string query, object parameters = null)
        {
            return (await _conn.QueryAsync<T>(query, parameters)).ToList();
        }

        public async Task<T> QuerySingleAsync<T>(string query, object parameters = null)
        {
            return await _conn.QuerySingleAsync<T>(query, parameters);
        }

        public async Task<T> QueryFirstAsync<T>(string query, object parameters = null)
        {
            return await _conn.QueryFirstAsync<T>(query, parameters);
        }

        public async Task ExecuteAsync(string query, object parameters = null)
        {
            await _conn.ExecuteAsync(query, parameters);
        }
    }
}
