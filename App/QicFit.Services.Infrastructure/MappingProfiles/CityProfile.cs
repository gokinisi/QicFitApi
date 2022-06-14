
using AutoMapper;
using Common.Entities;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class CityProfile : Profile
    {

        public CityProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}

