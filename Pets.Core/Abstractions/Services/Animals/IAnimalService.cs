using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Services.Animals
{
    public interface IAnimalService
    {
        Task<List<AnimalEntity>> GetAllCatsByNameAsync(string animalName);

        Task<List<AnimalEntity>> GetAllCatsByTypeAsync(AnimalType type);
    }
}
