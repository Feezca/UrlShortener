using Microsoft.EntityFrameworkCore;
using UrlShortener.Proyecto.Entities;

namespace UrlShortener.Proyecto.Data
{
    public class UrlShortenerContext :DbContext
        {
        public DbSet<Url> Urls { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User Admin = new User()
            {
                Id = 1,
                Username = "Admin",
                Password = "12345",
                Email = "admin1234@gmail.com",
            };
            User luis = new User()
            {
                Id = 2,
                Username = "Luis Gonzalez",
                Password = "65432",
                Email = "elluismidetotoras@gmail.com",
            };
            Category social = new Category()
            {
                Id = 1,
                CategoryName = "Sociales"
            };
            Category deportes = new Category()
            {
                Id = 2,
                CategoryName = "Deportivas"
            };
            Category multimedia = new Category()
            {
                Id = 3,
                CategoryName = "Multimedia"
            };
            modelBuilder.Entity<User>().HasData(
                Admin, luis);
            modelBuilder.Entity<Category>().HasData(
                social, deportes, multimedia);

            modelBuilder.Entity<Url>()
            .HasOne(url => url.User)
            .WithMany()
            .HasForeignKey(url => url.UserId);
            
            modelBuilder.Entity<Url>()
            .HasOne(u => u.Category)
            .WithMany()
            .HasForeignKey(u => u.CategoryId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
