using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Domain.Entities
{
    public class Food
    {
        private Food() { }

        public Food(string name, AnimalType type, int count)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Значение не может быть пустым или пробелом", nameof(name));

            if (count <= 0)
                throw new ArgumentOutOfRangeException("Количество корма не может быть меньше или равным нулю", nameof(count));

            Name = name;
            Type = type;
            Count = count;
        }

        public Guid Id { get; init; }

        public string Name { get; init; }

        public AnimalType Type{ get; init; }

        public int Count { get; private set; }


        public void Increase(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Количество корма не может быть меньше или равным нулю", nameof(count));
            Count += count;
        }

        public void Decrease(int count)
        {
            Count -= count;
        }
    }
}
