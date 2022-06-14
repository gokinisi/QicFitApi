using Common.DTO;
using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class ParticipantService : BaseService, IParticipantService
    {
        protected readonly IUserRepository userRepository;

        public ParticipantService(ICurrentContextProvider contextProvider, IUserRepository userRepository) : base(contextProvider)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetByWorkoutId(int id)
        {
            var users = await userRepository.GetByWorkout(id, Session);

            return users.MapTo<IEnumerable<UserDTO>>();
        }
    }
}
