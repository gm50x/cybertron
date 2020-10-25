using System;

namespace Cybertron.Core.Interfaces.Bases
{
    public interface ICommand {
        void Activate();
    }

    public interface ICommand<TOutput>
    {
        TOutput Activate();
    }

    public interface ICommand<TInput, TOutput>
    {
        TOutput Activate(TInput input);
    }
}
