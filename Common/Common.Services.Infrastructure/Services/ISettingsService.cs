
using Common.DTO;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface ISettingsService
    {
        Task<SettingsDTO> GetById(int id);

        Task<SettingsDTO> Edit(SettingsDTO settings);
    }
}