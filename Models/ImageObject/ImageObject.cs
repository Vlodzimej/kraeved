using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KraevedAPI.Models
{
    public class ImageObject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название изображения
        /// </summary>
        public string? Name { get; set; } = string.Empty;

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Данные
        /// </summary>

        public byte[]? Data { get; set; } = null;
    }
}