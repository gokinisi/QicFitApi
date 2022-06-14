using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class UserLocationProfile : Profile
    {

        public UserLocationProfile()
        {
            CreateMap<UserLocation, UserLocationDTO>().ReverseMap();
        }
    }
}

