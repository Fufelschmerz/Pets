using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Repositories
{
    public interface IBreedRepository
    {
        Task AddBreedAsync(Breed breed);
 
        Task<List<Breed>> GetAllBreedsByNameAsync(string name);

        Task<List<Breed>> GetAllBreedsByTypeAsync(AnimalType type);

        Task<bool> CheckIsBreedlWithNameAndTypeExistAsync(string name, AnimalType type);

        Task<Breed> GetBreedAsync(string name, AnimalType type);
    }
}
