using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Cinema;
using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Service
{
    public class FilmeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add( filme);
            
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
                filmes = _context.Filmes.ToList();
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            var listReadFilmeDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
            return listReadFilmeDto;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            return filme != null ? _mapper.Map<ReadFilmeDto>(filme) : null;
        }


        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return Result.Fail("Filme nao encontrado");

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return Result.Fail("Filme nao encontrado");

            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}