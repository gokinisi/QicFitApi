using Common.DataAccess.EFCore;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class WorkoutLocationRepository : BaseRepository<WorkoutLocation, QicFitDataContext>, IWorkoutLocationRepository
    {
        public WorkoutLocationRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(WorkoutLocation obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.WorkoutLocations.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<WorkoutLocation>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            return await context.WorkoutLocations.Where(w => w.Active == true).OrderBy(o => o.Name).ToArrayAsync(); 
        }

        public override async Task<WorkoutLocation> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.WorkoutLocations
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WorkoutLocation>> GetByUser(int userId, ContextSession session)
        {
            var context = GetContext(session);

            return await (
                from w in context.WorkoutLocations
                join c in context.City on w.CityId equals c.Id
                join s in context.State on w.StateId equals s.Id
                join ul in context.UserLocations on c.Id equals ul.CityId
                join u in context.Users on ul.UserId equals u.Id
                where s.Id == ul.StateId
                select new WorkoutLocation {Id = w.Id, Name = w.Name, Street = w.Street, CityId = w.CityId,
                                           StateId = w.StateId, Longitude = w.Longitude, Latitude = w.Latitude,
                                           City = w.City, State = w.State})
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}
