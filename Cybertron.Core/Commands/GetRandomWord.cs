using System;
using System.Linq;
using System.Threading.Tasks;
using Cybertron.Core.Interfaces.Commands;
using Cybertron.Core.Interfaces.Services;
using Cybertron.Infrastructure.Interfaces;

namespace Cybertron.Core.Commands
{
    public class GetRandomWord : IGetRandomWord
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationService _notification;
        public GetRandomWord(IUnitOfWork uow, INotificationService notification)
        {
            _uow = uow;
            _notification = notification;
        }

        public async Task<string> Activate()
        {
            var words = (await _uow.GetRepository<IDictRepository>()
                                        .GetAllDictionaryEntires())
                                        .Select(x => x.Word).ToArray();
            var random = new Random();
            return words[random.Next(words.Length)];
        }
    }
}
