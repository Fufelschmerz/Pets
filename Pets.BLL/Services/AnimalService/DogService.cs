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
    public class DogService : IDogService 
    {
        private readonly IAnimalRepository<Dog> _animalRepository;

        private readonly IBreedRepository _breedRepository;

        public DogService(IAnimalRepository<Dog> animalRepository, IBreedRepository breedRepository)
        {
            _animalRepository = animalRepository;
            _breedRepository = breedRepository;
        }

        public async Task CreateDogAsync(string animalName, Breed breed, decimal tailLength)
        {
            if (await _animalRepository.CheckIsAnimalWithNameAndTypeExistAsync(animalName, AnimalType.Dog))
                throw new AnimalAlreadyExistsException();

            if (await _breedRepository.CheckIsBreedlWithNameAndTypeExistAsync(breed.Name, breed.Type))
                breed = await _breedRepository.GetBreedAsync(breed.Name, breed.Type);

            var dog = new Dog(animalName, breed, tailLength);

            await _animalRepository.AddAnimalAsync(dog);
        }

        public async Task<Dog> GetDogByNameAsync(string animalName)
        {
            return await _animalRepository.GetAnimalByNameAsync(animalName)
                ?? throw new NotAnimalExeption();
        }

    }
}
