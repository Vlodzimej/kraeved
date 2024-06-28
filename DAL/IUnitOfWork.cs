using KraevedAPI.DAL.Repository;
using KraevedAPI.Models;

namespace KraevedAPI.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        GenericRepository<GeoObject> GeoObjectsRepository { get; }
        GenericRepository<HistoricalEvent> HistoricalEventsRepository { get; }
        GenericRepository<GeoObjectType> GeoObjectTypesRepository { get; }
        GenericRepository<ImageObject> ImageObjectsRepository { get; }
        GenericRepository<User> UsersRepository { get; }
        GenericRepository<SmsCode> SmsCodesRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
