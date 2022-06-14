
using Common.Entities;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface ISettingsRepository
    {
        Task<Settings> Get(int id, ContextSession session);
        Task<Settings> Edit(Settings setting, ContextSession session);
    }
}