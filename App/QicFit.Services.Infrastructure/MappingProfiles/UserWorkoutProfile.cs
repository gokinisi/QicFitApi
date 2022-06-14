using AutoMapper;
using QicFit.DTO;
using QicFit.Entities;

namespace QicFit.Services.Infrastructure.MappingProfiles
{
    public class UserWorkoutProfile : Profile
    {
        public UserWorkoutProfile()
        {
            CreateMap<UserWorkout, UserWorkoutDTO>()
                .ForSourceMember(x => x.UpdatedByUserId, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.UpdatedDate, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreatedByUserId, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.CreatedDate, opt => opt.DoNotValidate());

            CreateMap<UserWorkoutDTO, UserWorkout>();
               
        }
    }
}
