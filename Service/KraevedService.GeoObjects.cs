using KraevedAPI.Constants;
using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial class KraevedService : IKraevedService
    {
        /// <summary>
        /// Получение гео-объекта по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор гео-объекта</param>
        /// <returns></returns>
        public Task<GeoObject> GetGeoObjectById(int id)
        {
            var result = _unitOfWork.GeoObjectsRepository.GetByID(id) ?? 
                throw new Exception(ServiceConstants.Exception.NotFound);

            return Task.FromResult(result);
        }

        /// <summary>
        /// Получение списка гео-объектов по фильтру
        /// </summary>
        /// <param name="filter">Фильтр гео-объекта</param>
        /// <returns></returns>
        public Task<IEnumerable<GeoObjectBrief>> GetGeoObjectsByFilter(GeoObjectFilter filter)
        {
            //TODO: Поправить поиск по имени с приведением в нижний регистр
            var result = _unitOfWork.GeoObjectsRepository
                .Get(x => 
                    (filter.Name == null || x.Name.ToLower().Contains(filter.Name.ToLower())) && 
                    (filter.RegionId == null || (filter.RegionId == x.RegionId)),                         
                    x => x.OrderBy(item => item.Name))
                .Select(_mapper.Map<GeoObjectBrief>) ?? throw new Exception(ServiceConstants.Exception.UnknownError);

            return Task.FromResult(result);
        }

        /// <summary>
        /// Добавление гео-объекта в БД
        /// </summary>
        /// <param name="geoObject"></param>
        /// <returns></returns>
        public async Task<GeoObject> InsertGeoObject(GeoObject geoObject)
        {
            Validate(geoObject);
            var filter = new GeoObjectFilter() { Name = geoObject.Name, RegionId = geoObject.RegionId };
            var existedGeoObjectList = await GetGeoObjectsByFilter(filter);
            if (existedGeoObjectList.FirstOrDefault() != null) {
                throw new Exception(ServiceConstants.Exception.ObjectExists);
            }
     
            _unitOfWork.GeoObjectsRepository.Insert(geoObject);
            await _unitOfWork.SaveAsync();

            var newGeoObject = _unitOfWork.GeoObjectsRepository
                .Get(x => 
                    (x.Name == geoObject.Name) && 
                    (x.Latitude == geoObject.Latitude) && 
                    (x.Longitude == geoObject.Longitude) && 
                    (x.Description == geoObject.Description))
                .FirstOrDefault() ?? throw new Exception(ServiceConstants.Exception.CreatedObjectNotFound);

            return newGeoObject;
        }

        /// <summary>
        /// Удаление гео-объекта по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GeoObject> DeleteGeoObject(int id)
        {
            var geoObject = _unitOfWork.GeoObjectsRepository.Get(x => id == x.Id).FirstOrDefault() ??
                throw new Exception(ServiceConstants.Exception.NotFound);

            _unitOfWork.GeoObjectsRepository.Delete(id);
            await _unitOfWork.SaveAsync();

            return geoObject;
        }

        /// <summary>
        /// Изменение гео-объекта
        /// </summary>
        /// <param name="geoObject"></param>
        /// <returns></returns>
        public async Task<GeoObject> UpdateGeoObject(GeoObject geoObject)
        {
            var existingGeoObject = _unitOfWork.GeoObjectsRepository.Get(x => geoObject.Id == x.Id).FirstOrDefault() ?? 
                throw new Exception(ServiceConstants.Exception.NotFound);
            Validate(existingGeoObject);

            existingGeoObject.Name = geoObject.Name;
            existingGeoObject.Description = geoObject.Description;
            existingGeoObject.Longitude = geoObject.Longitude;
            existingGeoObject.Latitude = geoObject.Latitude;                
            existingGeoObject.RegionId = geoObject.RegionId;

            _unitOfWork.GeoObjectsRepository.Update(existingGeoObject);
            await _unitOfWork.SaveAsync();

            return existingGeoObject;
        }

        /// <summary>
        /// Валидация объекта исторического события
        /// </summary>
        /// <param name="historicalEvent"></param>
        private void Validate(GeoObject? geoObject) {
            if (geoObject == null) {
                throw new Exception(ServiceConstants.Exception.ObjectEqualsNull);
            }

            string[] errorMessages = [];

            var nameLenght = geoObject.Name.Trim().Length;

            if (nameLenght == 0) {
                errorMessages.Append("Не заполнено название");
            }

            if (nameLenght > 100) {
                errorMessages.Append("Название не должно превышать 100 символов");
            }

            //TODO: Сделать полную валидацию

            if (errorMessages.Length > 0) {
                throw new Exception(string.Join("\n", errorMessages));
            }
        }
    }
}
