using Cybertron.Core.Interfaces.Commands;
using Cybertron.Core.Interfaces.Services;
using Cybertron.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertron.Core.Commands
{
    public class GetAllWords : IGetAllWords
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationService _notification;
        public GetAllWords(IUnitOfWork uow, INotificationService notification)
        {
            _uow = uow;
            _notification = notification;
        }

        public async Task<string[]> Activate()
        {
            var dicts = await _uow.GetRepository<IDictRepository>().GetAllDictionaryEntires();
            return dicts.Select(x => x.Word).ToArray();
        }
    }
}
