using Microsoft.EntityFrameworkCore;
using Pets.Core.Abstractions.Repositories;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.DataAccess.Repository.Feedings
{
    public class FeedingRepository : IFeedingRepository
    {
        private readonly DataContext _dataContext;

        public FeedingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Добавить кормление животного
        /// </summary>
        /// <param name="feeding"></param>
        /// <returns></returns>
        public async Task AddFeedingAsync(Feeding feeding)
        {
            await _dataContext.Feedings.AddAsync(feeding);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получить историю всех кормлений
        /// </summary>
        /// <returns></returns>
        public async Task<List<Feeding>> GetFeedingHistoryAsync()
        {
            return await _dataContext.Feedings
                .Include(x => x.Food)
                .Include(x => x.Animal)
                .ToListAsync();
        }

        /// <summary>
        /// Получить историю кормлений для определённого животного
        /// </summary>
        /// <param name="name">Имя животного</param>
        /// <returns></returns>
        public async Task<List<Feeding>> GetFeedingHistoryByAnimalNameAsync(string name)
        {
            return await _dataContext.Feedings
                .Include(x => x.Food)
                .Where(x => x.Animal.Name.Equals(name))
                .ToListAsync();
        }
    }
}
