using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.Controllers.DTO.Breed.Request;
using Pets.Controllers.DTO.Breed.Response;
using Pets.Core.Abstractions.Services.Breeds;
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
    public class BreedController : ControllerBase
    {
        private readonly IBreedService _breedService;

        private readonly IMapper _mapper;

        public BreedController(IBreedService breedService, IMapper mapper)
        {
            _breedService = breedService;
            _mapper = mapper;
        }

        [HttpPost("CreateBreed")]
        public async Task<IActionResult> CreateBreedAsync(CreateBreedRequest model)
        {
            if (model == null)
                return BadRequest();

            await _breedService.CreateBreedAsync(model.Name, model.Type);

            return Ok();
        }

        [HttpGet("GetBreedsByName")]
        public async Task<ActionResult<List<ItemBreedResponse>>> GetBreedsByNameAsync(string name)
        {
            var breeds = await _breedService.GetAllBreedsByNameAsync(name);

            if (breeds.Count == 0)
                return NotFound("Пароды не найдены");

            return _mapper.Map<List<Breed>, List<ItemBreedResponse>>(breeds);
        }

        [HttpGet("GetBreedsByType")]
        public async Task<ActionResult<List<ItemBreedResponse>>> GetBreedsByTypeAsync(AnimalType type)
        {
            var breeds = await _breedService.GetAllBreedsByTypeAsync(type);

            if (breeds.Count == 0)
                return NotFound("Пароды не найдены");

            return _mapper.Map<List<Breed>, List<ItemBreedResponse>>(breeds);
        }
    }
}
