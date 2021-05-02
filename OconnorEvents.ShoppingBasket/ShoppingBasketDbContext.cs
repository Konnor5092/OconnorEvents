using Microsoft.EntityFrameworkCore;
using OconnorEvents.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket
{
    public class ShoppingBasketDbContext : DbContext
    {
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options) : base(options) { }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BasketChangeEvent> BasketChangeEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DateTime eventDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John Egbert Live",
                Date = eventDate.AddMonths(6),
                Price = 65,
                Artist = "John Egbert",
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/banjo.jpg", 
                VenueName = "Massey Hall",
                VenueCity = "Toronto",
                VenueCountry = "Canada",
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "The State of Affairs: Michael Live!",
                Date = eventDate.AddMonths(9),
                Price = 85,
                Artist = "Michael Johnson",
                Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/michael.jpg",
                VenueName = "Massey Hall",
                VenueCity = "Toronto",
                VenueCountry = "Canada",
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Clash of the DJs",
                Date = eventDate.AddMonths(4),
                Price = 85,
                Artist = "DJ 'The Mike'",
                Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                ImageUrl = "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/dj.jpg",
                VenueName = "L'Olympia",
                VenueCity = "Montreal",
                VenueCountry = "Canada",
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "Spanish guitar hits with Manuel",
                Price = 25,
                Artist = "Manuel Santinonisi",
                Date = eventDate.AddMonths(4),
                Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                ImageUrl = "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/guitar.jpg",
                VenueName = "L'Olympia",
                VenueCity = "Montreal",
                VenueCountry = "Canada",
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "Techorama 2021",
                Price = 400,
                Artist = "Many",
                Date = eventDate.AddMonths(10),
                Description = "The best tech conference in the world",
                ImageUrl = "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/conf.jpg",
                VenueName = "Commodore Ballroom",
                VenueCity = "Vancouver",
                VenueCountry = "Canada",
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Name = "To the Moon and Back",
                Price = 135,
                Artist = "Nick Sailor",
                Date = eventDate.AddMonths(8),
                Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                ImageUrl = "https://neilmorrisseypluralsight.blob.core.windows.net/imgs/musical.jpg",
                VenueName = "Commodore Ballroom",
                VenueCity = "Vancouver",
                VenueCountry = "Canada",
            });
        }
    }
}
