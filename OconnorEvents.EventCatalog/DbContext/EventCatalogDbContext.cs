

using Microsoft.EntityFrameworkCore;
using OconnorEvents.EventCatalog.Entities;

namespace OconnorEvents.EventCatalog.DbContext
{
    public class EventCatalogDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EventCatalogDbContext(DbContextOptions<EventCatalogDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
