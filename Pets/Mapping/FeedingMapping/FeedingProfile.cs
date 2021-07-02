using AutoMapper;
using Pets.Controllers.DTO.Feeding.Response;
using Pets.Core.Domain.ValueObjects;

namespace Pets.Mapping.FeedingMapping
{
    public class FeedingProfile : Profile
    {
        public FeedingProfile()
        {
            CreateMap<Feeding, ItemFeedingHistoryResponse>();

            CreateMap<Feeding, ItemFeedingHistoryShortResponse>();
        }
    }
}
