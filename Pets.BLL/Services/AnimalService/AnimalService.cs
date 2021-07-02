using Pets.Core.Abstractions.Repositories;
using Pets.Core.Abstractions.Services.Animals;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.BLL.Services.AnimalService
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository<AnimalEntity> _animalRepository;

        public AnimalService(IAnimalRepository<AnimalEntity> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<AnimalEntity>> GetAllCatsByNameAsync(string animalName)
        {
            return await _animalRepository.GetAllAnimalsByNameAsync(animalName);
        }

        public async Task<List<AnimalEntity>> GetAllCatsByTypeAsync(AnimalType type)
        {
            return await _animalRepository.GetAllAnimalsByTypeAsync(type);
        }


    }
}
