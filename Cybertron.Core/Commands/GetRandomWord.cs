using System;
using System.Linq;
using System.Threading.Tasks;
using Cybertron.Core.Interfaces.Commands;
using Cybertron.Infrastructure.Interfaces;

namespace Cybertron.Core.Commands
{
    public class GetRandomWord : IGetRandomWord
    {
        private readonly IUnitOfWork _uow;

        public GetRandomWord(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> Activate()
        {
            var words = (await _uow.Dictionary.GetAllDictionaryEntires()).Select(x => x.Word).ToArray();
            var random = new Random();
            return words[random.Next(words.Length)];
        }
    }
}
