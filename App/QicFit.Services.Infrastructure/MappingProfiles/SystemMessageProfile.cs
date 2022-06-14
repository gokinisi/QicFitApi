using AutoMapper;
using Common.Entities;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class SystemMessageProfile : Profile
    {

        public SystemMessageProfile()
        {
            CreateMap<SystemMessage, SystemMessageDTO>().ReverseMap();
        }
    }
}

