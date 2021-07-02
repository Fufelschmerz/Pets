using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.Controllers.DTO.Feeding.Response;
using Pets.Core.Abstractions.Services.Feedings;
using Pets.Core.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Pets.Controllers.Feedings
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FeedingController : ControllerBase
    {
        private readonly IFeedingService _feedingService;

        private readonly IMapper _mapper;

        public FeedingController(IFeedingService feedingService, IMapper mapper)
        {
            _feedingService = feedingService;
            _mapper = mapper;
        }

        [HttpGet("GetFeedingHistory")]
        public async Task<ActionResult<List<ItemFeedingHistoryResponse>>> GetFeedingHistoryAsync()
        {
            var feedingHistory = await _feedingService.GetFeedingHistoryAsync();

            if (feedingHistory.Count == 0)
                return NotFound("История кормлений пуста");

            return _mapper.Map<List<Feeding>, List<ItemFeedingHistoryResponse>>(feedingHistory);
        }
    }
}
