using Cybertron.Core.Interfaces.Commands;
using Cybertron.Core.Interfaces.Services;
using Cybertron.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Cybertron.Core.Commands
{
    public class GetWordByName : IGetWordByName
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationService _notification;
        public GetWordByName(IUnitOfWork uow, INotificationService notification)
        {
            _uow = uow;
            _notification = notification;
        }
        public async Task<string> Activate(string name)
        {
            var dicts = await _uow.GetRepository<IDictRepository>()
                                    .GetDictionaryEntryByWord(name);

            return dicts.Word;
        }
    }
}
