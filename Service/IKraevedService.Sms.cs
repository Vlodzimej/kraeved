namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<String> SendSms(string message);
    }
}
