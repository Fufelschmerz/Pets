using Pets.Core.Domain.Entities;
using System;

namespace Pets.Core.Domain.ValueObjects
{
    public class Feeding
    {
        private Feeding() { }

        public Feeding(Food food, AnimalEntity animal, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Количество корма не может быть меньше или равным нулю");

            Date = DateTime.UtcNow;
            Food = food ?? throw new ArgumentNullException(nameof(food));
            Animal = animal ?? throw new ArgumentNullException(nameof(animal));
            Count = count;
        }

        public Guid Id { get; init; }

        public DateTime Date { get; init; }
        public int Count { get; init; }

        public Food Food { get; init; }

        public AnimalEntity Animal { get; init; }
    }
}
