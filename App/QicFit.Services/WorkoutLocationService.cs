using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class WorkoutLocationService : BaseService, IWorkoutLocationService
    {
        protected readonly IWorkoutLocationRepository locationRepository;

        public WorkoutLocationService(ICurrentContextProvider contextProvider, IWorkoutLocationRepository locationRepository) : base(contextProvider)
        {
            this.locationRepository = locationRepository;
        }
        public async Task<IEnumerable<WorkoutLocationDTO>> GetAll()
        {
            var locations = await locationRepository.GetList(Session);

            return locations.MapTo<IEnumerable<WorkoutLocationDTO>>();
        }

        public async Task<WorkoutLocationDTO> GetById(int id)
        {
            var location = await locationRepository.Get(id, Session);

            return location.MapTo<WorkoutLocationDTO>();
        }

        public async Task<WorkoutLocationDTO> Update(WorkoutLocationDTO location)
        {
            var result = await locationRepository.Edit(location.MapTo<WorkoutLocation>(), Session);
            return result.MapTo<WorkoutLocationDTO>();
        }

        public async Task<IEnumerable<WorkoutCityGroupDTO>> GetByUser(int id)
        {
            var l = await locationRepository.GetByUser(id, Session);
            var locations = l.MapTo<IEnumerable<WorkoutLocationDTO>>();

            var group = locations.GroupBy(x => new { x.City.County, x.State.Code })
                .Select(w => new WorkoutCityGroupDTO()
                {
                    Name = $"{w.Key.County}, {w.Key.Code}",
                    WorkoutLocations = w.Select(wl => new WorkoutLocationGroupDTO() { Name = wl.Name, Id = wl.Id}).ToList()
                });

            return group;
        }

        public async Task<WorkoutLocationDTO> Create(WorkoutLocationDTO location)
        {
            try
            {
                var result = await locationRepository.Edit(location.MapTo<WorkoutLocation>(), Session);
                return result.MapTo<WorkoutLocationDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
    }
}
