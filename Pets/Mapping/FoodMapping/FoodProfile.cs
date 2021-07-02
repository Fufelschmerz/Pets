using AutoMapper;
using Pets.Controllers.DTO.Food.Response;
using Pets.Core.Domain.Entities;

namespace Pets.Mapping.FoodMapping
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, ItemFoodResponse>();
        }
    }
}
