using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.Controllers.DTO.Animal.Request;
using Pets.Controllers.DTO.Animal.Responce;
using Pets.Controllers.DTO.Feeding.Response;
using Pets.Core.Abstractions.Animals.Services;
using Pets.Core.Abstractions.Services.Feedings;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.Animal
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        private readonly IMapper _mapper;

        private readonly IFeedingService _feedingService;

        public DogController(IDogService dogService, IMapper mapper, IFeedingService feedingService)
        {
            _dogService = dogService;
            _mapper = mapper;
            _feedingService = feedingService;
        }

        [HttpPost("CreateDog")]
        public async Task<IActionResult> CreateDogAsync(CreateAnimalRequest model)
        {
            if (model == null)
                return BadRequest();

            var breed = _mapper.Map<Breed>(model);

            await _dogService.CreateDogAsync(model.AnimalName, breed, model.AdditionalParameter);

            return Ok();
        }

        [HttpGet("GetDog")]
        public async Task<ActionResult<Tuple<DogResponse, List<ItemFeedingHistoryShortResponse>>>> GetCatAsync(string name)
        {
            var dog = _mapper.Map<DogResponse>(await _dogService.GetDogByNameAsync(name));

            var feedingHistory = _mapper.Map<List<Feeding>, List<ItemFeedingHistoryShortResponse>>(await _feedingService.GetFeedingsHistoryAsync(dog.Name));

            return Tuple.Create(dog, feedingHistory);
        }
    }
}
