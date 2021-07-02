using Pets.Core.Abstractions.Animals.Services;
using Pets.Core.Abstractions.Repositories;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using Pets.Core.Exceptions.AnimalExceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.BLL.Services.AnimalService
{
    public class CatService : ICatService
    {
        private readonly IAnimalRepository<Cat> _animalRepository;

        private readonly IBreedRepository _breedRepository;

        public CatService(IAnimalRepository<Cat> animalRepository, IBreedRepository breedRepository)
        {
            _animalRepository = animalRepository;
            _breedRepository = breedRepository;
        }


        public async Task CreateCatAsync(string animalName, Breed breed, decimal weight)
        {
            if (await _animalRepository.CheckIsAnimalWithNameAndTypeExistAsync(animalName, AnimalType.Cat))
                throw new AnimalAlreadyExistsException();

            if (await _breedRepository.CheckIsBreedlWithNameAndTypeExistAsync(breed.Name, breed.Type))
                breed = await _breedRepository.GetBreedAsync(breed.Name, breed.Type);
            
            var cat = new Cat(animalName, breed, weight);

            await _animalRepository.AddAnimalAsync(cat);
        }

        public async Task<Cat> GetCatByNameAsync(string name)
        {
            return await _animalRepository.GetAnimalByNameAsync(name)
                ?? throw new NotAnimalExeption();
        }
    }
}
