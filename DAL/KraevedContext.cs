using KraevedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KraevedAPI.DAL
{
    public class KraevedContext : DbContext
    {
        public KraevedContext()
        {
        }

        public KraevedContext(DbContextOptions<KraevedContext> options) : base(options)
        {
        }

        public DbSet<GeoObject> GeoObjects => Set<GeoObject>();
        public DbSet<HistoricalEvent> HistoricalEvents => Set<HistoricalEvent>();
        public DbSet<ImageObject> ImageObjects => Set<ImageObject>();
    }
}
