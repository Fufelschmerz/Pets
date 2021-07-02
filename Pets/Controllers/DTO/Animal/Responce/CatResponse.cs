using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Animal.Responce
{
    public class CatResponse
    {
        public string Name { get; set; }
        
        public string BreedName { get; set; }

        public decimal Weight { get; set; }
    }
}
