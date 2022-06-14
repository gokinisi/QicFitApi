
using Common.Entities;
using QicFit.Entities;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure
{
    public interface IContactPhotoRepository
    {
        Task<ContactPhoto> Get(int id, ContextSession session);
    }
}
