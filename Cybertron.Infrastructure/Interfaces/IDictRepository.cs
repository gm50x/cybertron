﻿using Cybertron.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertron.Infrastructure.Interfaces
{
    public interface IDictRepository
    {
        Task<IList<Dict>> GetAllDictionaryEntires();
        Task<Dict> GetDictionaryEntryByWord(string word);
    }
}
