using System;
using System.Threading.Tasks;

namespace Cybertron.Core.Interfaces.Bases
{
    public interface ICommandAsync {
        void Activate();
    }

    public interface ICommandAsync<TOutput>
    {
        Task<TOutput> Activate();
    }

    public interface ICommandAsync<TInput, TOutput>
    {
        Task<TOutput> Activate(TInput input);
    }
}
