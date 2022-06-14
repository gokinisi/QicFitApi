
using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace QicFit.DataAccess.EFCore
{
    public class UserPhotoRepository : BaseRepository<UserPhoto, QicFitDataContext>, IUserPhotoRepository
    {
        public UserPhotoRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(UserPhoto obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserPhotos.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public override async Task<UserPhoto> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserPhotos.Where(obj => obj.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
