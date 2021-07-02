using Microsoft.EntityFrameworkCore;
using Pets.Core.Abstractions.Repositories;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.DataAccess.Repository.Breeds
{
    public class BreedRepository : IBreedRepository
    {
        private readonly DataContext _dataContext;

        public BreedRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Добавить породу
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public async Task AddBreedAsync(Breed breed)
        {
            await _dataContext.AnimalBreeds.AddAsync(breed);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Проверить породу на наличие
        /// </summary>
        /// <param name="name">Название породы</param>
        /// <param name="type">Тип</param>
        /// <returns></returns>
        public async Task<bool> CheckIsBreedlWithNameAndTypeExistAsync(string name, AnimalType type)
        {
            return await _dataContext.AnimalBreeds.AnyAsync(b=>b.Name.Equals(name) && b.Type == type);
        }

        /// <summary>
        /// Получить список всех пород по названию
        /// </summary>
        /// <param name="name">Название породы</param>
        /// <returns></returns>
        public async Task<List<Breed>> GetAllBreedsByNameAsync(string name)
        {
            return await _dataContext.AnimalBreeds
                .Where(b => b.Name.Equals(name))
                .ToListAsync();
        }

        /// <summary>
        /// Получить список всех пород по типу животного
        /// </summary>
        /// <param name="type">Тип животного</param>
        /// <returns></returns>
        public async Task<List<Breed>> GetAllBreedsByTypeAsync(AnimalType type)
        {
            return await _dataContext.AnimalBreeds
                .Where(b => b.Type == type)
                .ToListAsync();
        }

        /// <summary>
        /// Получить породу по названию и типу
        /// </summary>
        /// <param name="name">Название породы</param>
        /// <param name="type">Тип</param>
        /// <returns></returns>
        public async Task<Breed> GetBreedAsync(string name, AnimalType type)
        {
            return await _dataContext.AnimalBreeds.FirstOrDefaultAsync(b=>b.Name.Equals(name) && b.Type == type);
        }
    }
}
