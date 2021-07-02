using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Animals.Services
{
    public interface IDogService
    {
        Task CreateDogAsync(string animalName, Breed breed, decimal tailLength);

        Task<Dog> GetDogByNameAsync(string animalName);
    }
}
