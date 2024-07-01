namespace KraevedAPI.Models
{
    /// <summary>
    /// Данные пользователя после входа в систему.
    /// </summary>
    public class LoginOutDto
    {
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
