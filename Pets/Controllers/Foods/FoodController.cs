using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.Controllers.DTO.Food.Request;
using Pets.Controllers.DTO.Food.Response;
using Pets.Core.Abstractions.Services.Foods;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Pets.Controllers.Foods
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;

        public FoodController(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }
        
        [HttpPost("CreateFood")]
        public async Task<IActionResult> CreateFoodAsync(CreateFoodRequest model)
        {
            if (model == null)
                return BadRequest();

            await _foodService.CreateFoodAsync(model.Name, model.Type, model.Count);

            return Ok();
        }

        [HttpGet("GetFoodByName/{name}")]
        public async Task<ActionResult<List<ItemFoodResponse>>> GetFoodByNameAsync(string name)
        {
            var foods = await _foodService.GetAllFoodByNameAsync(name);

            if (foods.Count == 0)
                return NotFound("Корм не найден");

            return _mapper.Map<List<Food>, List<ItemFoodResponse>>(foods);
        }

        [HttpGet("GetFoodByType/{type}")]
        public async Task<ActionResult<List<ItemFoodResponse>>> GetFoodByTypeAsync(AnimalType type)
        {
            var foods = await _foodService.GetAllFoodByTypeAsync(type);

            if (foods.Count == 0)
                return NotFound("Корм не найден");

            return _mapper.Map<List<Food>, List<ItemFoodResponse>>(foods);
        }

        [HttpPut("UpdateCountFood")]
        public async Task<IActionResult> UpdateCountFoodAsync(string name, int count)
        {
            await _foodService.AddCountFoodAsync(name, count);

            return Ok();
        }
    }
}
