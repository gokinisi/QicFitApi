using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class WorkoutLocationProfile : Profile
    {

        public WorkoutLocationProfile()
        {
            CreateMap<WorkoutLocation, WorkoutLocationDTO>().ReverseMap();
        }
    }
}

