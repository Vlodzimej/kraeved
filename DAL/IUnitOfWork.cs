using KraevedAPI.DAL.Repository;
using KraevedAPI.Models;

namespace KraevedAPI.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        GenericRepository<GeoObject> GeoObjectsRepository { get; }
        GenericRepository<HistoricalEvent> HistoricalEventsRepository { get; }
        GenericRepository<ImageObject> ImageObjectsRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
