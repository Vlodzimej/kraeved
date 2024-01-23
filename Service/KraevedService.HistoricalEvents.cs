using System.Linq;
using KraevedAPI.Constants;
using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial class KraevedService : IKraevedService
    {
        /// <summary>
        /// Получение исторического события 
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public Task<HistoricalEvent> GetHistoricalEventById(int id) {
            var historicalEvent = _unitOfWork.HistoricalEventsRepository.GetByID(id) ?? throw new Exception(ServiceConstants.Exception.NotFound);
            
            return Task.FromResult(historicalEvent);
        }

        /// <summary>
        /// Получение списка исторических событий
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <returns></returns>
        public Task<IEnumerable<HistoricalEventBrief>> GetHistoricalEventsByFilter(HistoricalEventFilter filter) {
            var historicalEvents = _unitOfWork.HistoricalEventsRepository
                .Get(x => (filter.Name == null || x.Name.ToLower().Contains(filter.Name.ToLower())) &&
                          (filter.Date == null || (filter.Date == x.Date)), 
                     x => x.OrderBy(item => item.Name))
                .Select(_mapper.Map<HistoricalEventBrief>) ?? throw new Exception(ServiceConstants.Exception.UnknownError); 

            return Task.FromResult(historicalEvents);
        }
        
        /// <summary>
        /// Добавление нового исторического события
        /// </summary>
        /// <param name="historicalEvent">Историческое событие</param>
        /// <returns></returns>
        public async Task<HistoricalEvent> InsertHistoricalEvent(HistoricalEvent historicalEvent) {
            Validate(historicalEvent);

            _unitOfWork.HistoricalEventsRepository.Insert(historicalEvent);
            await _unitOfWork.SaveAsync();
 
            var newHistoricalEvent = _unitOfWork.HistoricalEventsRepository
                .Get(x => 
                    (x.Name == historicalEvent.Name) && 
                    (x.Date == historicalEvent.Date) && 
                    (x.Description == historicalEvent.Description))
                .FirstOrDefault()  ?? throw new Exception(ServiceConstants.Exception.CreatedObjectNotFound);

            return newHistoricalEvent;
        }

        /// <summary>
        /// Удаление исторического события
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public async Task<HistoricalEvent> DeleteHistoricalEvent(int id) {
            var historicalEvent = _unitOfWork.HistoricalEventsRepository.Get(x => id == x.Id).FirstOrDefault() ?? throw new Exception(ServiceConstants.Exception.NotFound); 

            _unitOfWork.HistoricalEventsRepository.Delete(id);
            await _unitOfWork.SaveAsync();

            return historicalEvent;
        }

        /// <summary>
        /// Изменение исторического события
        /// </summary>
        /// <param name="historicalEvent">Историческое событие</param>
        /// <returns></returns>
        public async Task<HistoricalEvent> UpdateHistoricalEvent(HistoricalEvent historicalEvent) {
            var existedHistoricalObject = _unitOfWork.HistoricalEventsRepository.Get(x => historicalEvent.Id == x.Id).FirstOrDefault() ?? throw new Exception(ServiceConstants.Exception.NotFound); 
            Validate(historicalEvent);

            // Изменения названия
            if (historicalEvent.Name != existedHistoricalObject.Name)
            {
                existedHistoricalObject.Name = historicalEvent.Name;
            }

            if (historicalEvent.Date != existedHistoricalObject.Date)
            {
                existedHistoricalObject.Date = historicalEvent.Date;
            }

            if (historicalEvent.Description != existedHistoricalObject.Description)
            {
                existedHistoricalObject.Description = historicalEvent.Description;
            }

            if (historicalEvent.Images != existedHistoricalObject.Images)
            {
                existedHistoricalObject.Images = historicalEvent.Images;
            }
            

            _unitOfWork.HistoricalEventsRepository.Update(existedHistoricalObject);
            await _unitOfWork.SaveAsync();

            return existedHistoricalObject;
        }

        /// <summary>
        /// Валидация объекта исторического события
        /// </summary>
        /// <param name="historicalEvent"></param>
        private void Validate(HistoricalEvent? historicalEvent) {
            if (historicalEvent == null) {
                throw new Exception(ServiceConstants.Exception.ObjectEqualsNull);
            }

            string[] errorMessages = [];

            var nameLenght = historicalEvent.Name.Trim().Length;

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