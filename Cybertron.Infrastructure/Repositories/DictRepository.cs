using Cybertron.Domain.Entities;
using Cybertron.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Cybertron.Infrastructure.Repositories
{
    public class DictRepository : Repository, IDictRepository
    {
        private const string SCHEMA = "CYBERTRON";
        private const string TABLE = "DICTIONARY";

        public DictRepository(IDbConnection conn) : base(conn) { }

        public async Task<IList<Dict>> GetAllDictionaryEntires()
        {
            var query = $@"SELECT * FROM {SCHEMA}.{TABLE}";
            return (await QueryAsync<Dict>(query)).ToList();
        }

        public async Task<Dict> GetDictionaryEntryByWord(string word)
        {
            var query = $@"SELECT * FROM {SCHEMA}.{TABLE} WHERE WORD = :WORD";
            return await QuerySingleAsync<Dict>(query, new { WORD = word });
        }

        public async Task AddDictEntry(Dict dict)
        {
            var query = $@"INSERT INTO {SCHEMA}.{TABLE} (WORD, DESCRIPTION)
                            VALUES (:WORD, :DESCRIPTION)
                        ";
            await ExecuteAsync(query, new
            {
                WORD = dict.Word,
                DESCRIPTION = dict.Description
            });
        }
    }
}
