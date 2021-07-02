using Pets.Core.Abstractions.Repositories;
using Pets.Core.Abstractions.Services.Foods;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using Pets.Core.Exceptions.FoodException;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.BLL.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task AddCountFoodAsync(string name, int count)
        {
            var food = await _foodRepository.GetFoodByNameAsync(name)
                ?? throw new NotFoodException();
            
            food.Increase(count);

            await _foodRepository.UpdateCountFoodAsync(food);
        }

        public async Task CreateFoodAsync(string foodName, AnimalType type, int count)
        {
            if (await _foodRepository.CheckIsFoodWithNameAndTypeExistAsync(foodName, type))
                throw new FoodAlreadyExistsException();

            var food = new Food(foodName, type, count);

            await _foodRepository.AddFoodAsync(food);
        }

        public async Task<List<Food>> GetAllFoodByNameAsync(string name)
        {
            return await _foodRepository
                .GetAllFoodByNameAsync(name);
        }

        public async Task<List<Food>> GetAllFoodByTypeAsync(AnimalType type)
        {
            return await _foodRepository
                .GetAllFoodByTypeAsync(type);
        }
    }
}
