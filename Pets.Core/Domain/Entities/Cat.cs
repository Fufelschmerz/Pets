using Pets.Core.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Core.Domain.Entities
{
    [Table("Cat")]
    public class Cat : AnimalEntity
    {
        private Cat() { }

        public Cat(string name, Breed breed, decimal weight):base(AnimalType.Cat, name, breed)
        {
            if (weight <= 0)
                throw new ArgumentOutOfRangeException("Вес кошки не может быть меньше или равным нулю",nameof(weight));

            if (breed.Type != AnimalType.Cat)
                throw new ArgumentException("Это парода для собаки", nameof(breed));

            Weight = weight;
        }


        public decimal Weight { get; init; }
    }
}
