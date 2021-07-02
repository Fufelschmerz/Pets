using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Domain.Entities
{
    public class Breed
    {
        private Breed() { }

        public Breed(string name, AnimalType type)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Значение не может быть пустым или пробелом", nameof(name));

            Name = name;
            Type = type;
        }

        public Guid Id { get; init; }
        
        public string Name { get; init; }

        public AnimalType Type { get; init; }
    }
}
