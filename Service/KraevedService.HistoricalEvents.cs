using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
            var existingHistoricalObject = _unitOfWork.HistoricalEventsRepository.Get(x => historicalEvent.Id == x.Id).FirstOrDefault() ?? throw new Exception(ServiceConstants.Exception.NotFound); 
            Validate(historicalEvent);

            existingHistoricalObject.Name = historicalEvent.Name;
            existingHistoricalObject.Date = historicalEvent.Date;
            existingHistoricalObject.Description = historicalEvent.Description;
            existingHistoricalObject.Images = historicalEvent.Images;
            existingHistoricalObject.Thumbnail = historicalEvent.Thumbnail;
            _unitOfWork.HistoricalEventsRepository.Update(existingHistoricalObject);
            await _unitOfWork.SaveAsync();

            return existingHistoricalObject;
        }

        /// <summary>
        /// Валидация объекта исторического события
        /// </summary>
        /// <param name="historicalEvent"></param>
        private void Validate(HistoricalEvent? historicalEvent) {
            if (historicalEvent == null) {
                throw new Exception(ServiceConstants.Exception.ObjectEqualsNull);
            }

            List<string> errorMessages = [];

            var nameLenght = historicalEvent.Name.Trim().Length;

            if (nameLenght == 0) {
                errorMessages.Add("Не заполнено название");
            }

            if (nameLenght > 100) {
                errorMessages.Add("Название не должно превышать 100 символов");
            }

            //TODO: Сделать полную валидацию
            if (errorMessages.Count() > 0) {
                throw new Exception(string.Join("\n", errorMessages));
            }
        }
    }
}