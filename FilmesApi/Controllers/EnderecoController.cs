using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Models;
using FilmesApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
            => _enderecoService = enderecoService;

        [HttpGet]
        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            return _enderecoService.RecuperaEnderecos();
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _enderecoService.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            var endereco = _enderecoService.RecuperaEnderecosPorId(id);
            if (endereco != null) return Ok(endereco);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            return _enderecoService.AtualizaEndereco(id, enderecoDto).IsFailed ? NotFound() : NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            return _enderecoService.DeletaEndereco(id).IsFailed ? NotFound() : NoContent(); ;
        }
    }
}