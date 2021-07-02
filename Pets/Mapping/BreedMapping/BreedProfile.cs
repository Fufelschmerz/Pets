using AutoMapper;
using Pets.Controllers.DTO.Breed.Response;
using Pets.Core.Domain.Entities;

namespace Pets.Mapping.BreedMapping
{
    public class BreedProfile: Profile
    {
        public BreedProfile()
        {
            CreateMap<Breed, ItemBreedResponse>();
        }
    }
}
