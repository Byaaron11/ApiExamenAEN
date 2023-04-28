using ApiExamenAEN.Models;
using ApiExamenAEN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenAEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeriesPersonajes repo;

        public PersonajesController(RepositorySeriesPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]/{idSerie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesSeries(int idSerie)
        {
            return await this.repo.GetPersonajesSerie(idSerie);
        }

        [HttpGet]

        public async Task<ActionResult<List<Personaje>>> GetPersonajeSeries()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("{idPersonaje}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int idPersonaje)
        {
            return await this.repo.FindPersonaje(idPersonaje);
        }

        [HttpPost]
        public async Task<ActionResult> InsertarPersonaje(Personaje pj)
        {
            await this.repo.InsertarPersonajeAsync(pj.Nombre, pj.Imagen, pj.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje pj)
        {
            await this.repo.UpdatePersonaje(pj.IdSerie, pj.Nombre, pj.Imagen);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateSerie(Personaje pj)
        {
            await this.repo.UpdatePersonajeSerie(pj.IdPersonaje, pj.IdSerie);
            return Ok();
        }

        [HttpDelete]
        [Route("{idPersonaje}")]
        public async Task<ActionResult> DeleteSerie(int idPersonaje)
        {
            await this.repo.DeletePerosnajeAsync(idPersonaje);
            return Ok();
        }
    }
}
