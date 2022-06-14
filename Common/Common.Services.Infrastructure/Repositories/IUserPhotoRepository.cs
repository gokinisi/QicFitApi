
using Common.Entities;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IUserPhotoRepository
    {
        Task<UserPhoto> Get(int id, ContextSession session);
    }
}
