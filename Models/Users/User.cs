using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KraevedAPI.Models {
    
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Phone { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
    }
}