using AutoMapper;
using Pets.Controllers.DTO.Animal.Request;
using Pets.Controllers.DTO.Animal.Responce;
using Pets.Core.Domain.Entities;
using Pets.Core.Domain.Enums;

namespace Pets.Mapping.AnimalMapping
{
    public class AnimalProfile: Profile
    {
        public AnimalProfile()
        {
            CreateMap<CreateAnimalRequest, Breed>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x=>x.BreedName));

            CreateMap<Cat, ItemAnimalShortResponse>();

            CreateMap<Dog, ItemAnimalShortResponse>();

            CreateMap<Cat, CatResponse>();

            CreateMap<Dog, DogResponse>();
        }
    }
}
