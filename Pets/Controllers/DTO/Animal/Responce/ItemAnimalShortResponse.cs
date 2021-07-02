using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Animal.Responce
{
    public class ItemAnimalShortResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public string BreedName { get; set; }
    }
}
