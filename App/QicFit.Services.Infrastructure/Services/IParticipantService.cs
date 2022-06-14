using Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IParticipantService
    {
        Task <IEnumerable<UserDTO>> GetByWorkoutId(int id);
    }
}
