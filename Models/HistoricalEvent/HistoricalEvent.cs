using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KraevedAPI.Models
{
    /// <summary>
    /// Историческое событие
    /// </summary>
    public class HistoricalEvent
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
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? Date { get; set; }      

        /// <summary>
        /// Галлерея
        /// </summary>
        /// <value></value>
        public ICollection<ImageObject> Images { get; set; } = [];
    }
}