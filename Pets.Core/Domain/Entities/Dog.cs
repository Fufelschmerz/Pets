using Pets.Core.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Core.Domain.Entities
{
    [Table("Dog")]
    public class Dog : AnimalEntity
    {
        private Dog() { }

        public Dog(string name, Breed breed, decimal tailLength) : base(AnimalType.Dog, name, breed)
        {
            if (tailLength <= 0)
                throw new ArgumentOutOfRangeException("Длина хвоста собаки не может быть отрицательной или равно нулю", nameof(tailLength));

            if (breed.Type != AnimalType.Dog)
                throw new ArgumentException("Это не собака", nameof(breed));

            TailLength = tailLength;
        }


        public decimal TailLength { get; init; }
    }
}
