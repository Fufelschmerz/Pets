using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Food.Request
{
    public class CreateFoodRequest
    {
        [Required(ErrorMessage = "Укажите название корма")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите для какого животного корм")]
        public AnimalType Type { get; set; }

        [Required(ErrorMessage = "Введите количество корма")]
        public int Count { get; set; }
    }
}
