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
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public ImageObject? icon { get; set; }

        /// <summary>
        /// Данные
        /// </summary>

        public byte[] Content { get; set; } = [];
    }
}