using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Services.Foods
{
    public interface IFoodService
    {
        Task CreateFoodAsync(string foodName, AnimalType type, int count);

        Task AddCountFoodAsync(string name, int count);

        Task<List<Food>> GetAllFoodByNameAsync(string name);

        Task<List<Food>> GetAllFoodByTypeAsync(AnimalType type);
    }
}
