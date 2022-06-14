using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class PreNotificationProfile : Profile
    {

        public PreNotificationProfile()
        {
            CreateMap<PreNotification, PreNotificationDTO>().ReverseMap();
        }
    }
}

