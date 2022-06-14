using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class GenderProfile : Profile
    {

        public GenderProfile()
        {
            CreateMap<Gender, GenderDTO>().ReverseMap();
        }
    }
}

