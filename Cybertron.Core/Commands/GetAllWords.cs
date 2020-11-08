using Cybertron.Core.Interfaces.Commands;
using Cybertron.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertron.Core.Commands
{
    public class GetAllWords : IGetAllWords
    {
        private readonly IUnitOfWork _uow;
        public GetAllWords(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<string[]> Activate()
        {
            var dicts = await _uow.GetRepository<IDictRepository>().GetAllDictionaryEntires();
            return dicts.Select(x => x.Word).ToArray();
        }
    }
}
