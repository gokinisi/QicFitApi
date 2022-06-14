using AutoMapper;
using Common.Entities;
using QicFit.DTO;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class StateProfile : Profile
    {

        public StateProfile()
        {
            CreateMap<State, StateDTO>().ReverseMap();
        }
    }
}

