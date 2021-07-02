using Pets.Core.Abstractions.Repositories;
using Pets.Core.Abstractions.Services.Feedings;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.ValueObjects;
using Pets.Core.Exceptions.AnimalExceptions;
using Pets.Core.Exceptions.FoodException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.BLL.Services.FeedingService
{
    public class FeedingService : IFeedingService
    {
        private readonly IFeedingRepository _feedingRepository;

        private readonly IAnimalRepository<AnimalEntity> _animalRepository;

        private readonly IFoodRepository _foodRepository;

        public FeedingService(IFeedingRepository feedingRepository, IAnimalRepository<AnimalEntity> animalRepository,  IFoodRepository foodRepository)
        {
            _feedingRepository = feedingRepository;
            _animalRepository = animalRepository;
            _foodRepository = foodRepository;
        }

        public async Task FeedAnimalAsync(string animalName, string foodName, int count)
        {
            var animal = await _animalRepository.GetAnimalByNameAsync(animalName)
                ?? throw new NotAnimalExeption();

            var food = await _foodRepository.GetFoodByNameAsync(foodName)
                ?? throw new NotFoodException();

            if (food.Count < count)
                throw new CountFoodException();

            if (animal.Type != food.Type)
                throw new TypeFoodException();

            var feeding = new Feeding(food, animal, count);
            feeding.Food.Decrease(count);
            await _feedingRepository.AddFeedingAsync(feeding);
        }

        public async Task<List<Feeding>> GetFeedingHistoryAsync()
        {
            return await _feedingRepository.GetFeedingHistoryAsync();
        }

        public async Task<List<Feeding>> GetFeedingsHistoryAsync(string name)
        {
            return await _feedingRepository.GetFeedingHistoryByAnimalNameAsync(name);
        }
    }
}
