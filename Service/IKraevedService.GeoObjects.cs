using KraevedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
#pragma warning disable IDE1006 // Стили именования
        Task<GeoObject?> getGeoObjectById(int id);
#pragma warning restore IDE1006 // Стили именования
#pragma warning disable IDE1006 // Стили именования
        Task<IEnumerable<GeoObjectBrief>> getGeoObjectsByFilter(GeoObjectFilter filter);
#pragma warning restore IDE1006 // Стили именования
#pragma warning disable IDE1006 // Стили именования
        Task<GeoObject?> insertGeoObject(GeoObject geoObject);
#pragma warning restore IDE1006 // Стили именования
#pragma warning disable IDE1006 // Стили именования
        Task<GeoObject?> deleteGeoObject(int id);
#pragma warning restore IDE1006 // Стили именования
#pragma warning disable IDE1006 // Стили именования
        Task<GeoObject?> updateGeoObject(GeoObject geoObject);
#pragma warning restore IDE1006 // Стили именования
    }
}
