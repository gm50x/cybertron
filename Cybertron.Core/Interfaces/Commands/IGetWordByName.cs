﻿using Cybertron.Core.Interfaces.Bases;

namespace Cybertron.Core.Interfaces.Commands
{
    public interface IGetWordByName : ICommandAsync<string, string>
    {
    }

}
