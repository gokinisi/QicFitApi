using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class RadiusProfile : Profile
    {

        public RadiusProfile()
        {
            CreateMap<Radius, RadiusDTO>().ReverseMap();
        }
    }
}

