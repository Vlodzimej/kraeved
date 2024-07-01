namespace KraevedAPI.Models
{

    /// <summary>
    /// Входящие данные для обновления данных пользователя
    /// </summary>
    public class UserInDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary> 
        public string? Surname { get; set; }
    }
}