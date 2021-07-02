using Microsoft.EntityFrameworkCore;
using Pets.Core.Abstractions.Repositories;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.DataAccess.Repository.Animals
{
    public class AnimalRepository<T> : IAnimalRepository<T> where T : AnimalEntity
    {
        private readonly DataContext _dataContext;

        public AnimalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Добавить животного
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <returns></returns>
        public async Task AddAnimalAsync(T animal)
        {
            await _dataContext.Set<T>().AddAsync(animal);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Проверить животное на наличие по имени и типу
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="type">Тип</param>
        /// <returns></returns>
        public async Task<bool> CheckIsAnimalWithNameAndTypeExistAsync(string name, AnimalType type)
        {
            return await _dataContext.Set<T>().AnyAsync(x => x.Name.Equals(name) && x.Type == type);
        }

        /// <summary>
        /// Получить список животных по имени
        /// </summary>
        /// <param name="name">Имя животного</param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAnimalsByNameAsync(string name)
        {
            return await _dataContext.Set<T>()
                .Where(x => x.Name.Equals(name))
                .Include(x=>x.Breed)
                .ToListAsync();
        }

        /// <summary>
        /// Получить список животных по типу
        /// </summary>
        /// <param name="type">тип</param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAnimalsByTypeAsync(AnimalType type)
        {
            return await _dataContext.Set<T>()
                .Where(x => x.Type == type)
                .Include(x=>x.Breed)
                .ToListAsync();
        }

        /// <summary>
        /// Получить животное по имени
        /// </summary>
        /// <param name="animalName">Имя животного</param>
        /// <returns></returns>
        public async Task<T> GetAnimalByNameAsync(string animalName)
        {
            return await _dataContext.Set<T>()
                .Include(x => x.Breed)
                .FirstOrDefaultAsync(x => x.Name.Equals(animalName));
        }
    }
}
