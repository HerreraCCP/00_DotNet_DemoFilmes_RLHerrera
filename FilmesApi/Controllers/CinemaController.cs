using System;
using FilmesApi.Data.Dtos.Cinema;
using FilmesApi.Service;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var readCinemaDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            var cinemas = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if (cinemas != null) return Ok(cinemas);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            var cinema = _cinemaService.RecuperaCinemasPorId(id);
            if (cinema != null) return Ok(cinema);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto) 
            => _cinemaService.AtualizaCinema(id, cinemaDto).IsFailed ? NotFound() : NoContent();

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id) 
            => _cinemaService.DeletaCinema(id).IsFailed ? NotFound() : NoContent();
    }
}