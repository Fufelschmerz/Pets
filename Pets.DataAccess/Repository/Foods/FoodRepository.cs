using Microsoft.EntityFrameworkCore;
using Pets.Core.Abstractions.Repositories;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.DataAccess.Repository.Foods
{
    public class FoodRepository : IFoodRepository
    {
        private readonly DataContext _dataContext;

        public FoodRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       
        /// <summary>
        /// Обновить количество корма
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public async Task UpdateCountFoodAsync(Food food)
        {
            _dataContext.Foods.Attach(food);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить корм
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public async Task AddFoodAsync(Food food)
        {
            await _dataContext.Foods.AddAsync(food);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Проверить наличие корма
        /// </summary>
        /// <param name="foodName">Название корма</param>
        /// <param name="type">Тип корма</param>
        /// <returns></returns>
        public async Task<bool> CheckIsFoodWithNameAndTypeExistAsync(string foodName, AnimalType type)
        {
            return await _dataContext.Foods
                .AnyAsync(f=>f.Name.Equals(foodName) && f.Type == type);
        }

        /// <summary>
        /// Получить все кормы по названию
        /// </summary>
        /// <param name="name">Название корма</param>
        /// <returns></returns>
        public async Task<List<Food>> GetAllFoodByNameAsync(string name)
        {
            return await _dataContext.Foods
                .Where(f => f.Name.Equals(name))
                .ToListAsync();
        }

        /// <summary>
        /// Получить все кормы по типу
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns></returns>
        public async Task<List<Food>> GetAllFoodByTypeAsync(AnimalType type)
        {
            return await _dataContext.Foods
                .Where(f => f.Type == type)
                .ToListAsync();
        }

        /// <summary>
        /// Получить корм по названию
        /// </summary>
        /// <param name="name">Название корма</param>
        /// <returns></returns>
        public async Task<Food> GetFoodByNameAsync(string name)
        {
            return await _dataContext.Foods
                .FirstOrDefaultAsync(f => f.Name.Equals(name));
        }
    }
}
