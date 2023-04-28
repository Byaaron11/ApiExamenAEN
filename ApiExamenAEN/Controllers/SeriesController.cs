using ApiExamenAEN.Models;
using ApiExamenAEN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenAEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeriesPersonajes repo;

        public SeriesController(RepositorySeriesPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet]
        [Route("{idSerie}")]
        public async Task<ActionResult<Serie>> GetSerie(int idSerie)
        {
            return await this.repo.FindSerieAsync(idSerie);
        }
    }
}
