using KraevedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<HistoricalEvent> GetHistoricalEventById(int id);
        Task<IEnumerable<HistoricalEventBrief>> GetHistoricalEventsByFilter(HistoricalEventFilter filter);
        Task<HistoricalEvent> InsertHistoricalEvent(HistoricalEvent historicalEvent);
        Task<HistoricalEvent> DeleteHistoricalEvent(int id);
        Task<HistoricalEvent> UpdateHistoricalEvent(HistoricalEvent historicalEvent);
    }
}
