using ApiExamenAEN.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAEN.Data
{
    public class SeriesPersonajesContext : DbContext
    {
        public SeriesPersonajesContext(DbContextOptions<SeriesPersonajesContext> options)
            : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
