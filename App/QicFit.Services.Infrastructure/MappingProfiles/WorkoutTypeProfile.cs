using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class WorkoutTypeProfile : Profile
    {
        public WorkoutTypeProfile()
        {
            CreateMap<WorkoutType, WorkoutTypeDTO>().ReverseMap();
        }
    }
}
