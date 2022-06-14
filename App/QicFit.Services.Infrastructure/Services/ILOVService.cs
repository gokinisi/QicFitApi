using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface ILovService
    {
        LovDTO GetAll();
        LovDTO GetWorkoutLocationsLov(int userId);
    }
}
