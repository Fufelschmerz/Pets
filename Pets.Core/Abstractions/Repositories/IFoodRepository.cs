using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Abstractions.Repositories
{
    public interface IFoodRepository
    {
        Task AddFoodAsync(Food food);

        Task UpdateCountFoodAsync(Food food);

        Task<Food> GetFoodByNameAsync(string name);

        Task<bool> CheckIsFoodWithNameAndTypeExistAsync(string foodName, AnimalType type);

        Task<List<Food>> GetAllFoodByNameAsync(string name);

        Task<List<Food>> GetAllFoodByTypeAsync(AnimalType type);
    }
}
