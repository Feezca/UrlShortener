using Microsoft.EntityFrameworkCore;
using UrlShortener.Proyecto.Entities;

namespace UrlShortener.Proyecto.Data
{
    public class UrlShortenerContext :DbContext
        {
   

        public DbSet<Url> Urls { get; set; }

        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) 
            //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                Url first = new Url()
                {
                    Id = 1,
                    NormalUrl = "mercadolibre.com",
                    ShortUrl = "..."
                };
                Url second = new Url()
                {
                    Id = 2,
                    NormalUrl = "locoarts.com",
                    ShortUrl = "..."
                };
                Url third = new Url()
                {
                    Id = 3,
                    NormalUrl = "netmentor.com",
                    ShortUrl = "..."
                };

                modelBuilder.Entity<Url>().HasData(
                first, second, third);

            base.OnModelCreating(modelBuilder);
        }
    }
}
