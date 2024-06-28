using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<Boolean> SendSms(string phone);
        Task<LoginOutDto> Login(LoginInDto loginDto);
    }
}
