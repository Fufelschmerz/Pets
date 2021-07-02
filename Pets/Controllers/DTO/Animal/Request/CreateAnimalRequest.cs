using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Animal.Request
{
    public class CreateAnimalRequest
    {
        [Required(ErrorMessage = "Вы забыли указать имя животного")]
        public string AnimalName { get; set; }

        [Required(ErrorMessage = "Укажите тип животного")]
        public AnimalType Type { get; set; }

        [Required(ErrorMessage = "Укажите название породы")]
        public string BreedName { get; set; }

        [Required(ErrorMessage = "Укажите дополнительный параметр")]
        public decimal AdditionalParameter { get; set; }
    }
}
