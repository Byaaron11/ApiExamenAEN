using ApiExamenAEN.Data;
using ApiExamenAEN.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAEN.Repositories
{
    public class RepositorySeriesPersonajes
    {
        private SeriesPersonajesContext context;

        public RepositorySeriesPersonajes(SeriesPersonajesContext context)
        {
            this.context = context;
        }

        #region SERIES
        private async Task<int> GetMaxSerieAsync()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Series.MaxAsync(z => z.IdSerie) + 1;
            }
        }
        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == id);
        }

        #endregion

        #region PERSONAJES
        public async Task<List<Personaje>> GetPersonajesSerie(int idSerie)
        {
            return await this.context.Personajes
                .Where(x => x.IdSerie == idSerie).ToListAsync();
        }

        private async Task<int> GetMaxPersonajeAsync()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Personajes.MaxAsync(z => z.IdPersonaje) + 1;
            }
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonaje(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task InsertarPersonajeAsync(string nombre, string imagen, int idSerie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = await this.GetMaxPersonajeAsync();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idSerie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePerosnajeAsync(int id)
        {
            Personaje pj = await this.FindPersonaje(id);
            this.context.Personajes.Remove(pj);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(int idPersonaje, string nombre, string imagen)
        {
            Personaje pj = await this.FindPersonaje(idPersonaje);
            pj.Nombre = nombre;
            pj.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }
        public async Task UpdatePersonajeSerie(int idPersonaje, int idSerie)
        {
            Personaje pj = await this.FindPersonaje(idPersonaje);
            pj.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }
        #endregion
    }
}
