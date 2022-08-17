using FilmesApi.Data.Dtos.Gerente;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Service;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService) => _gerenteService = gerenteService;

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            var gerente = _gerenteService.AdicionaGerente(gerenteDto);
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            var gerenteDto = _gerenteService.RecuperaGerentesPorId(id);
            if (gerenteDto != null) return Ok(gerenteDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id) => _gerenteService.DeletaGerente(id).IsFailed ? NotFound() : Ok();
    }
}