using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KraevedAPI.Models
{

    /// <summary>
    /// Код СМС для входа в систему.
    /// </summary>
    public class SmsCode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Phone { get; set; }
        public required string Code { get; set; }
        public required DateTime StartDate { get; set; }
        public bool IsInvalid { get; set; } = false;
    }
}