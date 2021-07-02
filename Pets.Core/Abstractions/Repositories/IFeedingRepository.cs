using Pets.Core.Domain.Entities;
using Pets.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Repositories
{
    public interface IFeedingRepository
    {
        Task AddFeedingAsync(Feeding feeding);

        Task<List<Feeding>> GetFeedingHistoryAsync();

        Task<List<Feeding>> GetFeedingHistoryByAnimalNameAsync(string name);
    }
}
