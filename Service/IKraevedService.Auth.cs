using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<Boolean> SendSms(string phone);
        Task<User> Login(LoginDto loginDto);
    }
}
