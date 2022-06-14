using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class AgeGroupProfile : Profile
    {

        public AgeGroupProfile()
        {
            CreateMap<AgeGroup, AgeGroupDTO>().ReverseMap();
        }
    }
}

