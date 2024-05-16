using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KraevedAPI.Models
{
    /// <summary>
    /// Историческое событие сокрещенное
    /// </summary>
    public class HistoricalEventBrief
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Миниатюрное изображение
        /// </summary>
        public string Thumbnail { get; set; } = string.Empty;
    }
}