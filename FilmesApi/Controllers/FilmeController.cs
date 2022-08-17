using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService) => _filmeService = filmeService;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _filmeService.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var readCinemaDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if (readCinemaDto != null) return Ok(readCinemaDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var readFilmeDto = _filmeService.RecuperaFilmesPorId(id);
            if (readFilmeDto != null) return Ok(readFilmeDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
            => _filmeService.AtualizaFilme(id, filmeDto).IsFailed ? NotFound() : NoContent();

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
            => _filmeService.DeletaFilme(id).IsFailed ? NotFound() : NoContent();
    }
}