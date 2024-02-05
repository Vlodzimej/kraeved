﻿namespace KraevedAPI.Models
{
    /// <summary>
    /// Географический объект сокращенный
    /// </summary>
    public class GeoObjectBrief
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Короткое описание
        /// </summary>
        public string ShortDescription { get; set; } = string.Empty;

        /// <summary>
        /// Тип локации
        /// </summary> <summary>
        /// 
        /// </summary>
        /// <value></value>
        public GeoObjectType? Type { get; set; }

        /// <summary>
        /// Широта
        /// </summary> 
        public double? Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Миниатюрное изображение
        /// </summary>
        /// <value></value>
        public string? ThumbnailUrl { get; set; } 
    }
}
