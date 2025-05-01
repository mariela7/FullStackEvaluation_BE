using MarcasAutosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<MarcaAuto> MarcasAutos => Set<MarcaAuto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto { Id = 1, Nombre = "Toyota" },
                new MarcaAuto { Id = 2, Nombre = "Ford" },
                new MarcaAuto { Id = 3, Nombre = "Chevrolet" },
                new MarcaAuto { Id = 4, Nombre = "Kia" },
                new MarcaAuto { Id = 5, Nombre = "Nissan" },
                new MarcaAuto { Id = 6, Nombre = "Reanult" }
            );
        }
    }
}
