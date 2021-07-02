using Pets.Core.Domain.Enums;
using Pets.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Domain.Entities
{
    public class AnimalEntity
    {
        protected AnimalEntity(){ }

        protected AnimalEntity(AnimalType type, string name, Breed breed)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Значение не может быть пустым или пробелом", nameof(name));

            if (breed.Type != type)
                throw new ArgumentException($"Похоже эта парода для собаки", nameof(breed));

            Type = type;
            Name = name;
            Breed = breed ?? throw new ArgumentNullException(nameof(breed));
        }

        public Guid Id { get; init; }

        public string Name { get; init; }

        public AnimalType Type { get; init; }

        public Breed Breed { get; init; }

        public IEnumerable<Feeding> Feedings { get; init; }
    }
}
