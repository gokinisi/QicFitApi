using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class WorkoutLocationRequirementProfile : Profile
    {

        public WorkoutLocationRequirementProfile()
        {
            CreateMap<WorkoutLocationRequirementProfile, WorkoutLocationRequirementDTO>().ReverseMap();
        }
    }
}

