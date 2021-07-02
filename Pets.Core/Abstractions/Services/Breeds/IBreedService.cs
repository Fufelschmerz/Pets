using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Services.Breeds
{
    public interface IBreedService
    {
        Task CreateBreedAsync(string breedName, AnimalType type);

        Task<List<Breed>> GetAllBreedsByNameAsync(string name);

        Task<List<Breed>> GetAllBreedsByTypeAsync(AnimalType type);
    }
}
