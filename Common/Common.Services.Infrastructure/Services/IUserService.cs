
using Common.DTO;
using Common.Entities;
using Common.Entities.System;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IUserService
    {
        Task<GridData<UserDTO>> GetDataForGrid(UsersGridFilter filter);
        Task<UserDTO> GetById(int id);
        Task<UserDTO> GetByName(string username);
        Task<bool> Delete(int id);
        Task<UserDTO> Edit(UserDTO dto);
        Task<byte[]> GetUserPhoto(int userId);
    }
}
