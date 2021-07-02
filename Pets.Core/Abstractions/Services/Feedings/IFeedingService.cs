using Pets.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Services.Feedings
{
    public interface IFeedingService
    {
        Task<List<Feeding>> GetFeedingsHistoryAsync(string name);

        Task FeedAnimalAsync(string animalName, string foodName, int count);

        Task<List<Feeding>> GetFeedingHistoryAsync();
    }
}
