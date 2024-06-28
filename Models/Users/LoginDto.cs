namespace KraevedAPI.Models {
    
    /// <summary>
    /// Данные для входа в систему.
    /// </summary>
    public class LoginDto {
        public required string Phone { get; set; }
        public string? Code { get; set; }
    }
}