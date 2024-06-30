using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<UserOutDto> GetCurrentUserInfd();
        Task<UserOutDto> PatchUser(UserInDto userInDto);
    }
}
