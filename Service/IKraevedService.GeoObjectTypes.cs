using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<GeoObjectType> GetGeoObjectTypeById(int id);
        Task<IEnumerable<GeoObjectType>> GetAllGeoObjectTypes();
        Task<GeoObjectType> InsertGeoObjectType(GeoObjectType geoObjectType);
        Task<GeoObjectType> DeleteGeoObjectType(int id);
        Task<GeoObjectType> UpdateGeoObjectType(GeoObjectType geoObjectType);
    }
}
