using Pets.Core.Abstractions.Repositories;
using Pets.Core.Abstractions.Services.Breeds;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using Pets.Core.Exceptions.BreedException;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.BLL.Services.BreedService
{
    public class BreedService : IBreedService
    {
        private readonly IBreedRepository _breedRepository;

        public BreedService(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }

        public async Task CreateBreedAsync(string breedName, AnimalType type)
        {
            if (await _breedRepository.CheckIsBreedlWithNameAndTypeExistAsync(breedName, type))
                throw new BreedAlreadyExistsException();

            var breed = new Breed(breedName, type);

            await _breedRepository.AddBreedAsync(breed);
        }

        public async Task<List<Breed>> GetAllBreedsByNameAsync(string name)
        {
            return await _breedRepository.GetAllBreedsByNameAsync(name);
        }

        public async Task<List<Breed>> GetAllBreedsByTypeAsync(AnimalType type)
        {
            return await _breedRepository.GetAllBreedsByTypeAsync(type);
        }
    }
}
