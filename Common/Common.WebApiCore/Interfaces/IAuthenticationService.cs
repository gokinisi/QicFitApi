
using Common.DTO;
using Common.WebApiCore.Identity;
using System.Threading.Tasks;

namespace Common.WebApiCore
{
    public interface IAuthenticationService
    {
        Task<AuthResult<Token>> Login(LoginDTO loginDto);
        Task<AuthResult<Token>> ChangePassword(ChangePasswordDTO changePasswordDto, int currentUserId);
        Task<AuthResult<Token>> SignUp(SignUpDTO signUpDto);
        Task<AuthResult<string>> RequestPassword(RequestPasswordDTO requestPasswordDto);
        Task<AuthResult<Token>> RestorePassword(RestorePasswordDTO restorePasswordDto);
        Task<AuthResult<Token>> SignOut();
        Task<AuthResult<Token>> RefreshToken(RefreshTokenDTO refreshTokenDto);
    }
}