using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutDTO>()
                .ForSourceMember(x => x.UpdatedByUserId, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdatedDate, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreatedByUserId, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreatedDate, opt => opt.DoNotValidate());

            CreateMap<WorkoutDTO, Workout>()
                .ForSourceMember(x => x.Participants, opt => opt.DoNotValidate());
        }
    }
}
