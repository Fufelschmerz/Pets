using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Breed.Response
{
    public class ItemBreedResponse
    {
        public string Name { get; set; }

        public AnimalType Type { get; set; }
    }
}
