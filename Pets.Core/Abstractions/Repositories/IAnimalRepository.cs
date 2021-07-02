using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Repositories
{
    public interface IAnimalRepository<T> where T : AnimalEntity
    {
        Task AddAnimalAsync(T animal);

        Task<List<T>> GetAllAnimalsByNameAsync(string name);

        Task<List<T>> GetAllAnimalsByTypeAsync(AnimalType type);

        Task<T> GetAnimalByNameAsync(string animalName);

        Task<bool> CheckIsAnimalWithNameAndTypeExistAsync(string name, AnimalType type);
    }
}
