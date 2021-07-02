using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Animals.Services
{
    public interface ICatService
    {
        Task CreateCatAsync(string animalName, Breed breed, decimal weight);

        Task<Cat> GetCatByNameAsync(string name);
    }
}
