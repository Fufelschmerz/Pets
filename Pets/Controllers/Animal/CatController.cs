using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pets.Controllers.DTO.Animal.Request;
using Pets.Controllers.DTO.Animal.Responce;
using Pets.Controllers.DTO.Feeding.Response;
using Pets.Core.Abstractions.Animals.Services;
using Pets.Core.Abstractions.Services.Feedings;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using Pets.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.Animal
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatController : ControllerBase
    {
        private readonly ICatService _catService;

        private readonly IFeedingService _feedingService;

        private readonly IMapper _mapper;

        public CatController(ICatService catService, IMapper mapper, IFeedingService feedingService)
        {
            _feedingService = feedingService;
            _catService = catService;
            _mapper = mapper;
        }

        [HttpPost("CreateCat")]
        public async Task<IActionResult> CreateCatAsync(CreateAnimalRequest model)
        {
            if (model == null)
                return BadRequest();

            var breed = _mapper.Map<Breed>(model);

            await _catService.CreateCatAsync(model.AnimalName, breed, model.AdditionalParameter);

            return Ok();
        }

        [HttpGet("GetCat")]
        public async Task<ActionResult<Tuple<CatResponse, List<ItemFeedingHistoryShortResponse>>>> GetCatAsync(string name)
        {
            var cat = _mapper.Map<CatResponse>(await _catService.GetCatByNameAsync(name));

            var feedingHistory = _mapper.Map<List<Feeding>, List<ItemFeedingHistoryShortResponse>>(await _feedingService.GetFeedingsHistoryAsync(cat.Name));

            return Tuple.Create(cat, feedingHistory);
        }
    }
}
