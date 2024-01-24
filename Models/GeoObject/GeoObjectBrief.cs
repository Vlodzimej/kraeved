using System.Drawing;

namespace KraevedAPI.Models
{
    /// <summary>
    /// Географический объект сокращенный
    /// </summary>
    public class GeoObjectBrief
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Короткое описание
        /// </summary>
        public string ShortDescription { get; set; } = string.Empty;

        /// <summary>
        /// Миниатюрное изображение
        /// </summary>
        /// <value></value>
        public string? ThumbnailUrl { get; set; } 
    }
}
