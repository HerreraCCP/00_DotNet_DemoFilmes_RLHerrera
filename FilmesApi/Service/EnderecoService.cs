using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Service
{
    public class EnderecoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadEnderecoDto> RecuperaEnderecos()
            => _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return null;

            var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return enderecoDto;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return Result.Fail("Nao foi possivel atualizar o endereco");

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return Result.Fail("Nao foi possivel deletar o endereco"); ;

            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}