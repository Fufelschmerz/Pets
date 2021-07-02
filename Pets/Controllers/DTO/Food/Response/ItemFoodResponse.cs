using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Food.Response
{
    public class ItemFoodResponse
    {
        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public int Count { get; set; }
    }
}
