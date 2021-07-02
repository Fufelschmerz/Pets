using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.Controllers.DTO.Animal.Responce;
using Pets.Core.Abstractions.Services.Animals;
using Pets.Core.Abstractions.Services.Feedings;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pets.Controllers.Animal
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        private readonly IFeedingService _feedingService;

        private readonly IMapper _mapper;

        public AnimalController(IAnimalService animalService, IMapper mapper, IFeedingService feedingService)
        {
            _animalService = animalService;
            _mapper = mapper;
            _feedingService = feedingService;
        }

        [HttpGet("GetAnimalsByName/{name}")]
        public async Task<ActionResult<List<ItemAnimalShortResponse>>>GetAnimalsByNameAsync(string name)
        {
            var animals = await _animalService.GetAllCatsByNameAsync(name);

            if (animals.Count == 0)
                return NotFound("Животные не найдены");

            return _mapper.Map<List<AnimalEntity>, List<ItemAnimalShortResponse>>(animals);
        }

        [HttpGet("GetAnimalsByType/{type}")]
        public async Task<ActionResult<List<ItemAnimalShortResponse>>> GetAnimalsByTypeAsync(AnimalType type)
        {
            var animals = await _animalService.GetAllCatsByTypeAsync(type);
           
            if (animals.Count == 0)
                return NotFound("Животные не найдены");

            return _mapper.Map<List<AnimalEntity>, List<ItemAnimalShortResponse>>(animals);
        }

        [HttpPost("FeedAnimal")]
        public async Task<IActionResult> FeedAnimalAsync(string animalName, string foodName, int count)
        {
            await _feedingService.FeedAnimalAsync(animalName, foodName, count);

            return Ok();
        }
    }
}
