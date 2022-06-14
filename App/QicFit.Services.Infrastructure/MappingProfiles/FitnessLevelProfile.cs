using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class FitnessLevelProfile : Profile
    {

        public FitnessLevelProfile()
        {
            CreateMap<FitnessLevel, FitnessLevelDTO>().ReverseMap();
        }
    }
}

