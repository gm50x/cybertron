using Cybertron.Core.Interfaces.Commands;
using Cybertron.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Cybertron.Core.Commands
{
    public class GetWordByName : IGetWordByName
    {
        private readonly IUnitOfWork _uow;
        public GetWordByName(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<string> Activate(string name)
        {
            var dicts = await _uow.GetRepository<IDictRepository>()
                                    .GetDictionaryEntryByWord(name);

            return dicts.Word;
        }
    }
}
