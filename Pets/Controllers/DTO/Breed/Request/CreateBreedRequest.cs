using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Breed.Request
{
    public class CreateBreedRequest
    {
        [Required(ErrorMessage = "Укажите название породы")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите тип животного")]
        public AnimalType Type { get; set; }
    }
}
